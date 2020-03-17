using iTextSharp.text.pdf;
using MHS.P4.Language;
using MHS.P4.OnlineReferrals.Models;
using MHS.P4.OnlineReferrals.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MHS.P4.OnlineReferrals.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration config;
        private P4OnlineReferralsContext dbContext;

        public HomeController(IConfiguration configuration, P4OnlineReferralsContext context)
        {
            config = configuration;
            dbContext = context;
        }

        [HttpGet]
        public IActionResult Index(string message)
        {
            Log.Debug("Getting view");
            var model = new PocketModel() { };
            try
            {
                ViewData["Message"] = message;

                model.IndicationCheckBoxes = getIndications();
                model.MedicationCheckBoxes = getMedications();
                model.GenderList = getGenderList();
                return View(model);
            }
            catch (Exception ex)
            {
                Log.Error("An error occured getting the pocket template. Exception: " + ex.Message.ToString());
            }
            return View(model);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(PocketModel model)
        {
            try
            {
                if (String.IsNullOrEmpty(model.ReferringPhysicianFax) && String.IsNullOrEmpty(model.ReferringPhysicianCPSO))
                {
                    ModelState.AddModelError("ReferringPhysicianFax", Locale.Error_CpsoOrFaxRequired);
                }
                if (!model.IndicationCheckBoxes.Any(x => x.IsChecked))
                {
                    ModelState.AddModelError("IndicationCheckBoxes", Locale.Error_ReasonForReferral);
                }
                if (ModelState.IsValid && !model.isError)
                {
                    bool result = FillForm(model);
                    if (result)
                    {
                        return RedirectToAction("Index", new { message = "Form submitted successfully!" });
                    }
                    else
                    {
                        model.Error = "An error occured submitting your form. IT has been notified. If error persists, please contact mHealth.";
                    }
                }
                model.GenderList = getGenderList();
                var indications = getIndications();
                var medications = getMedications();
                if (model.IndicationCheckBoxes.Any(x => x.IsChecked))
                {
                    foreach (var y in model.IndicationCheckBoxes.Where(x => x.IsChecked).ToList())
                    {
                        indications.Where(x => x.Id == y.Id).FirstOrDefault().IsChecked = true;
                    }
                }
                if (model.MedicationCheckBoxes.Any(x => x.IsChecked))
                {
                    foreach (var y in model.MedicationCheckBoxes.Where(x => x.IsChecked).ToList())
                    {
                        medications.Where(x => x.Id == y.Id).FirstOrDefault().IsChecked = true;
                    }
                }
                model.IndicationCheckBoxes = indications;
                model.MedicationCheckBoxes = medications;

            }
            catch (Exception ex)
            {
                Log.Error("An error occured saving form. Exception: " + ex.Message.ToString());
            }
            return View(model);
        }


        public List<IndicationCheckBoxes> getIndications()
        {
            var indicationCheckBoxes = new List<IndicationCheckBoxes>();
            try
            {

                var indicationList = dbContext.Indication.Where(x => x.VisibilityStatusType == 1).OrderBy(x => x.Position).ToList();
                foreach (var i in indicationList)
                {
                    indicationCheckBoxes.Add(new IndicationCheckBoxes()
                    {
                        Id = i.IndicationId.ToString(),
                        Name = i.Name,
                        HasNotes = i.HasNotes,
                        Notes = i.NotesPrompt,
                        IsChecked = false //none selected by default
                    });
                }
            }
            catch (Exception ex)
            {
                Log.Error("An error occured getting indications. Error: " + ex.Message.ToString());
            }
            return indicationCheckBoxes;

        }

        public List<MedicationCheckBoxes> getMedications()
        {
            var medicationCheckBoxes = new List<MedicationCheckBoxes>();
            try
            {
                var medicationList = dbContext.Medication.Where(x => x.VisibilityStatusType == 1).OrderBy(x => x.Position).ToList();

                foreach (var i in medicationList)
                {
                    medicationCheckBoxes.Add(new MedicationCheckBoxes()
                    {
                        Id = i.MedicationId.ToString(),
                        Name = i.Name,
                        HasNotes = i.HasNotes,
                        Notes = i.NotesPrompt,
                        IsChecked = false //none selected by default
                    });
                }
            }
            catch (Exception ex)
            {
                Log.Error("An error occured getting indications. Error: " + ex.Message.ToString());
            }
            return medicationCheckBoxes;
        }

        public List<SelectListItem> getGenderList()
        {
            var genderList = new List<SelectListItem>()
            {
                new SelectListItem(){Text="M",Value="M"},
                new SelectListItem(){Text="F",Value="F"}
            };
            return genderList;
        }

        public bool FillForm(PocketModel model)
        {
            try
            {
                string pdfTemplate = config["BlankPdf"];
                string newFile = config["SavePdf"] + DateTime.Now.ToString().Replace(":", "-").Replace("/", "-") + ".pdf";

                PdfReader pdfReader = new PdfReader(pdfTemplate);
                PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(newFile, FileMode.Create));
                AcroFields pdfFormFields = pdfStamper.AcroFields;

                pdfFormFields.SetField("ReferringPhysician", model.ReferringPhysicianName);
                pdfFormFields.SetField("RPFax", model.ReferringPhysicianFax);
                pdfFormFields.SetField("CPSO", model.ReferringPhysicianCPSO);
                pdfFormFields.SetField("IP", model.InterpretingPhysicianName);



                pdfFormFields.SetField("PatientName", model.PatientName);
                pdfFormFields.SetField("Gender", model.Gender);
                pdfFormFields.SetField("AddressLine1", model.AddressLine1);
                pdfFormFields.SetField("AddressLine2", model.AddressLine2);
                pdfFormFields.SetField("City", model.City);
                pdfFormFields.SetField("Province", model.Province);
                pdfFormFields.SetField("PostalCode", model.PostalCode);
                pdfFormFields.SetField("DOB", model.PatientDob);
                pdfFormFields.SetField("PatientPhone", model.PatientPhone);
                pdfFormFields.SetField("PatientHealthCardNum", model.PatientHealthCardNum);
                pdfFormFields.SetField("PatientHealthCardVersion", model.PatientHealthCardVersion);
                pdfFormFields.SetField("PatientCC", model.PatientCC);
                pdfFormFields.SetField("PatientCCFax", model.PatientCCFax);



                string indications = "", medications = "", testrequested = "", device = "";

                foreach (var x in model.IndicationCheckBoxes.Where(x => x.IsChecked))
                {
                    if (String.IsNullOrEmpty(x.Notes))
                    {
                        indications = indications + ", " + x.Name;
                    }
                    else
                    {
                        indications = indications + ", " + x.Name + ": " + x.Notes;
                    }
                }

                foreach (var x in model.MedicationCheckBoxes.Where(x => x.IsChecked))
                {
                    if (String.IsNullOrEmpty(x.Notes))
                    {
                        medications = medications + ", " + x.Name;
                    }
                    else
                    {
                        medications = medications + ", " + x.Name + ": " + x.Notes;
                    }
                }

                if (model.isPacemaker) { device = device + ", Pacemaker"; }
                if (model.isDefibrillator) { device = device + ", Implanted Cardiac Defibrillator"; }

                if (model.TestRequested2Weeks) { testrequested = testrequested + ", 2 weeks"; }
                if (model.TestRepeatInconclusive) { testrequested = testrequested + ", Repeat if inconclusive"; }

                pdfFormFields.SetField("Indications", indications);
                pdfFormFields.SetField("Medications", medications);
                pdfFormFields.SetField("Device", device);
                pdfFormFields.SetField("TestRequested", testrequested);
                // flatten the form to remove editting options, set it to false  
                // to leave the form open to subsequent manual edits  
                pdfStamper.FormFlattening = true;
                // close the pdf  
                pdfStamper.Close();


                return true;
            }
            catch (Exception ex)
            {
                Log.Error("An error occured adding fields in pdf. Error: " + ex.Message.ToString());
                return false;
            }
        }

    }
}
