using iTextSharp.text.pdf;
using Language;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using RegistrationFormDemo.Models;
using RegistrationFormDemo.Models.Database;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationFormDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;
        private RegistrationDemoContext _dbContext;

        public HomeController(IConfiguration configuration, RegistrationDemoContext context)
        {
            _config = configuration;
            _dbContext = context;
        }

        [HttpGet]
        public IActionResult Index(string message)
        {
            Log.Information("Getting home page view");
            var model = new RegistrationModel() { };
            try
            {
                ViewData["Message"] = message;
                model.ProvinceList = GetProvinceList();
                model.EventCheckBoxes = GetEvents();
                model.IsFirstTime = true;
                return View(model);
            }
            catch (Exception ex)
            {
                Log.Error($"An error occured getting the pocket template. Exception:  {ex.Message} {ex.InnerException}");
            }
            return View(model);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(RegistrationModel model)
        {
            try
            {
                Log.Information("Beginning to save form");
              
                if (ModelState.IsValid && !model.isError)
                {
                    bool resultDB = await SaveInDatabase(model);
                    if (!resultDB)
                    {
                        model.Error = Locale.Error_SubmitError;
                    }
                    else
                    {
                        if (model.EmailResult)
                        {
                            bool resultEmail = SendEmail(model.Email, model.FirstName, model.LastName);
                            if (!resultDB)
                            {
                                model.Error = Locale.Error_SendingEmail;
                            }
                            else
                            {
                                return RedirectToAction("Index", new { message = Locale.Text_SubmitSuccess });
                            }
                        }
                        else
                        {
                            return RedirectToAction("Index", new { message = Locale.Text_SubmitSuccess });
                        }
                    }
                    
                }
                model.ProvinceList = GetProvinceList();
                var eventCheckBoxes = GetEvents();
                if (model.EventCheckBoxes.Any(x => x.IsChecked))
                {
                    foreach (var y in model.EventCheckBoxes.Where(x => x.IsChecked).ToList())
                    {
                        eventCheckBoxes.Where(x => x.EventId == y.EventId).FirstOrDefault().IsChecked = true;
                    }
                }
                model.EventCheckBoxes = eventCheckBoxes;
            }
            catch (Exception ex)
            {
                Log.Error($"An error occured saving form for {model.FirstName} {model.LastName}. Phone: {model.Phone}. Email: {model.Email}. Exception:  {ex.Message} {ex.InnerException}");
            }
            return View(model);
        }



        public List<SelectListItem> GetProvinceList()
        {
            var provinceList = new List<SelectListItem>();
            try
            {
                provinceList.AddRange(_dbContext.Province
                    .OrderBy(x=>x.ProvinceName)
                    .Select(x =>
                    new SelectListItem
                    {
                        Text = x.ProvinceName,
                        Value = x.ProvinceId.ToString()
                    }
                ).ToList());
            }
            catch (Exception ex)
            {
                Log.Error($"An error occured getting ProvinceList. Error:  {ex.Message} {ex.InnerException}");
            }
            return provinceList;
        }

        public List<EventCheckBoxes> GetEvents()
        {
            var eventCheckBoxes = new List<EventCheckBoxes>();
            try
            {

                var eventList = _dbContext.Events.Where(x => !x.IsDeleted.Value).OrderBy(x => x.Position).ToList();
                foreach (var i in eventList)
                {
                    eventCheckBoxes.Add(new EventCheckBoxes()
                    {
                        EventId = i.EventId.ToString(),
                        Name = i.EventName,
                        IsChecked = false //none selected by default
                    });
                }
            }
            catch (Exception ex)
            {
                Log.Error($"An error occured getting events. Error:  {ex.Message} {ex.InnerException}");
            }
            return eventCheckBoxes;

        }


        public async Task<bool> SaveInDatabase(RegistrationModel model)
        {
            Log.Information("Beginning to save in db");

            try
            {
                Registrations registration = new Registrations();
                registration.FirstName = model.FirstName;
                registration.LastName = model.LastName;
                registration.Dob = DateTime.Parse(model.DateOfBirth);
                registration.AddressLine1 = model.AddressLine1;
                registration.AddressLine2 = model.AddressLine2;
                registration.City = model.City;
                registration.Province = Int32.Parse(model.SelectedProvince);
                registration.PostalCode = model.PostalCode;
                registration.PhoneNumber = model.Phone;
                registration.Email = model.Email;
                registration.IsFirstTime = model.IsFirstTime;
                registration.SendConfirmationEmail = model.EmailResult;
                registration.DateRegistered = DateTime.Now;
                _dbContext.Registrations.Add(registration);

                foreach(var selectedEvent in model.EventCheckBoxes.Where(x=>x.IsChecked))
                {
                    RegistrationEvent regEvent = new RegistrationEvent();
                    regEvent.EventId = Int32.Parse(selectedEvent.EventId);
                    regEvent.DateCreated = DateTime.Now;
                    registration.RegistrationEvent.Add(regEvent);
                }

                await _dbContext.SaveChangesAsync();

                Log.Information("Model saved in db successfully");
                return true;
            }
            catch (Exception ex)
            {
                Log.Error($"An error occured saving patient data in the database for pt {model.FirstName} {model.LastName}. Phone: {model.Phone}. Email: {model.Email}. Error: {ex.Message} {ex.InnerException}. Data: {model}");
            }

            return false;
        }

        public bool SendEmail(string email, string ptFirstName, string ptLastName)
        {
            Log.Information($"Beginning to send confirmation email to {email} for pt {ptFirstName} {ptLastName}");
            try
            {
                string host = _config["EmailSettings:Server"];
                string port = _config["EmailSettings:ServerPort"];
                SmtpClient client = new SmtpClient(host == null ? "192.168.80.249" : host);
                client.UseDefaultCredentials = _config["EmailSettings:UseDefaultCredentials"] == "true";
                client.EnableSsl = _config["EmailSettings:EnableSsl"] == "true";
                client.Port = int.Parse(port == null ? "25" : port);
                string patient = ptFirstName + ' ' + ptLastName.Substring(0, 1);

                var sb = new StringBuilder();
                sb.AppendLine(String.Format(Locale.Text_EmailLine1, patient));
                sb.AppendLine(Locale.Text_EmailLine2);
                sb.AppendLine();
                sb.AppendLine();
                sb.AppendLine(Locale.Text_ThankYou);
                sb.AppendLine(Locale.Text_EventTeam);

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(_config["EmailSettings:SendEmailFrom"]);
                mailMessage.To.Add(email);
                mailMessage.Bcc.Add(_config["EmailSettings:SendBcc"]);
                mailMessage.Body = sb.ToString();
                mailMessage.IsBodyHtml = false;
                mailMessage.Subject = Locale.Text_EmailSubject;
                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                Log.Error($"An error occured sending confirmation email to {email}. Error:  {ex.Message} {ex.InnerException}");
                return false;
            }
            return true;
        }

        public string GetStringEvents(List<EventCheckBoxes> values)
        {
            string events = "";
            try
            {
                events = String.Join(",", values);
            }
            catch (Exception ex)
            {
                Log.Error($"Error occured converting events to string. Error  {ex.Message} {ex.InnerException}. Events: {values.Select(x => x.Name.ToList())}");
            }

            return events;
        }


        [HttpGet]
        public IActionResult TermsAndConditions()
        {
            Log.Information("Getting TermsAndConditions view");
            return View();
        }


    }
}
