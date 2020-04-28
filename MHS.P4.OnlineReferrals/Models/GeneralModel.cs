using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MHS.P4.Language;
using MHS.P4.OnlineReferrals.Utilities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MHS.P4.OnlineReferrals.Models
{
    public class GeneralModel
    {

        public GeneralModel()
        {
            TestTypes = new List<SelectListItem>();
        }

        public bool isError { get; set; }
        public string Error { get; set; }

        [Display(Name = "Text_TestTypes", ResourceType = typeof(Locale))]
        public string TestType { get; set; }

        
        public List<SelectListItem> TestTypes { get; set; }

        //Physician Info
        [Display(Name = "ReferringPhysicianName", ResourceType = typeof(Locale))]
        [Required(ErrorMessageResourceName = "Error_ReferringPhysician", ErrorMessageResourceType = typeof(Locale))]
        public string ReferringPhysicianName { get; set; }


        [Display(Name = "Fax", ResourceType = typeof(Locale))]
        [RegularExpression(@"^[\d -]+$", ErrorMessageResourceName = "Error_PhoneFaxNumber", ErrorMessageResourceType = typeof(Locale))]
        public string ReferringPhysicianFax { get; set; }

        [Display(Name = "CPSO", ResourceType = typeof(Locale))]
        public string ReferringPhysicianCPSO { get; set; }


        [Display(Name = "CCName", ResourceType = typeof(Locale))]
        public string CCPhysicianName { get; set; }


        [Display(Name = "Fax", ResourceType = typeof(Locale))]
        public string CCPhysicianFax { get; set; }


        [Display(Name = "InterpretingPhysicianName", ResourceType = typeof(Locale))]
        //[Required(ErrorMessageResourceName = "Error_InterpretingPhysician", ErrorMessageResourceType = typeof(Locale))]
        public string InterpretingPhysicianName { get; set; }

        //Patient Info
        [Display(Name = "PatientName", ResourceType = typeof(Locale))]
        [Required(ErrorMessageResourceName = "Error_PatientName", ErrorMessageResourceType = typeof(Locale))]
        public string PatientName { get; set; }

        [Display(Name = "Gender", ResourceType = typeof(Locale))]
        [Required(ErrorMessageResourceName = "Error_PatientGender", ErrorMessageResourceType = typeof(Locale))]
        public string Gender { get; set; }


        public List<SelectListItem> GenderList { get; set; }


        [Required(ErrorMessageResourceName = "Error_DOBDay", ErrorMessageResourceType = typeof(Locale))]
        public string PatientDobDay { get; set; }
        [Required(ErrorMessageResourceName = "Error_DOBMonth", ErrorMessageResourceType = typeof(Locale))]
        public string PatientDobMonth { get; set; }
        [Required(ErrorMessageResourceName = "Error_DOBYear", ErrorMessageResourceType = typeof(Locale))]
        public string PatientDobYear { get; set; }

        [Display(Name = "Dob", ResourceType = typeof(Locale))]
        //[Required(ErrorMessageResourceName = "Error_DOB", ErrorMessageResourceType = typeof(Locale))]
        public string PatientDob { get; set; }


        [Display(Name = "AddressLine1", ResourceType = typeof(Locale))]
        [Required(ErrorMessageResourceName = "Error_PatientAddress", ErrorMessageResourceType = typeof(Locale))]
        public string AddressLine1 { get; set; }


        [Display(Name = "AddressLine2", ResourceType = typeof(Locale))]
        public string AddressLine2 { get; set; }


        [Display(Name = "City", ResourceType = typeof(Locale))]
        [Required(ErrorMessageResourceName = "Error_City", ErrorMessageResourceType = typeof(Locale))]
        public string City { get; set; }


        [Display(Name = "Province", ResourceType = typeof(Locale))]
        [Required(ErrorMessageResourceName = "Error_Province", ErrorMessageResourceType = typeof(Locale))]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessageResourceName = "Error_ProvinceChars", ErrorMessageResourceType = typeof(Locale))]
        public string Province { get; set; }


        [Display(Name = "PostalCode", ResourceType = typeof(Locale))]
        [Required(ErrorMessageResourceName = "Error_PostalCode", ErrorMessageResourceType = typeof(Locale))]
        [RegularExpression("[a-zA-Z][0-9][a-zA-Z] [0-9][a-zA-Z][0-9]", ErrorMessageResourceName = "Error_PostalCodeVal", ErrorMessageResourceType = typeof(Locale))]
        public string PostalCode { get; set; }


        [Display(Name = "Phone", ResourceType = typeof(Locale))]
        [Required(ErrorMessageResourceName = "Error_Phone", ErrorMessageResourceType = typeof(Locale))]
        [RegularExpression(@"^[\d -]+$", ErrorMessageResourceName = "Error_PhoneFaxNumber", ErrorMessageResourceType = typeof(Locale))]
        [StringLength(12, MinimumLength =12, ErrorMessageResourceName = "Error_PhoneFaxNumber", ErrorMessageResourceType = typeof(Locale))]
        public string PatientPhone { get; set; }


        [Display(Name = "PatientHealthCardNum", ResourceType = typeof(Locale))]
        [RequiredIf("InsuranceType", "Text_isPublicInsurance",1, ErrorMessageResourceName = "Error_HealthCardNum", ErrorMessageResourceType = typeof(Locale))]
        public string PatientHealthCardNum { get; set; }


        [Display(Name = "PatientHealthCardVersion", ResourceType = typeof(Locale))]
        //[RequiredIf("InsuranceType", "Text_isPublicInsurance", 1, ErrorMessageResourceName = "Error_HealthCardVersion", ErrorMessageResourceType = typeof(Locale))]
        public string PatientHealthCardVersion { get; set; }


        public string InsuranceType { get; set; }


        [Display(Name = "CCName", ResourceType = typeof(Locale))]
        public string PatientCC { get; set; }


        [Display(Name = "Fax", ResourceType = typeof(Locale))]
        [RegularExpression(@"^[\d -]+$", ErrorMessageResourceName = "Error_PhoneFaxNumber", ErrorMessageResourceType = typeof(Locale))]
        public string PatientCCFax { get; set; }


        [Required(ErrorMessageResourceName = "Error_ReasonForReferral", ErrorMessageResourceType = typeof(Locale))]
        public List<IndicationCheckBoxes> IndicationCheckBoxes { get; set; }


        public List<MedicationCheckBoxes> MedicationCheckBoxes { get; set; }


        [Display(Name = "Pacemaker", ResourceType = typeof(Locale))]
        public bool isPacemaker { get; set; }


        [Display(Name = "Defibrillator", ResourceType = typeof(Locale))]
        public bool isDefibrillator { get; set; }

        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessageResourceName = "TextIsHCP", ErrorMessageResourceType = typeof(Locale))]
        public bool isHCP { get; set; }

        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessageResourceName = "TextIsAcknowledge", ErrorMessageResourceType = typeof(Locale))]
        public bool isAcknowledge { get; set; }

        [Display(Name = "Notes", ResourceType = typeof(Locale))]
        public string Notes { get; set; }

        [Display(Name = "ConfirmationEmail", ResourceType = typeof(Locale))]
        [EmailAddress(ErrorMessageResourceName = "Error_EmailInvalid", ErrorMessageResourceType = typeof(Locale))]
        public string ConfirmationEmail { get; set; }


        [Display(Name = "Text_EmailResult", ResourceType = typeof(Locale))]
        public bool emailResult { get; set; }

    }
}
