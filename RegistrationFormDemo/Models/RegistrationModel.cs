using Language;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RegistrationFormDemo.Models
{
    public class RegistrationModel
    {

        public RegistrationModel()
        {
            ProvinceList = new List<SelectListItem>();
        }

        public bool isError { get; set; }
        public string Error { get; set; }

        [Display(Name = "Text_FirstName", ResourceType = typeof(Locale))]
        [Required(ErrorMessageResourceName = "Error_FirstNameRequired", ErrorMessageResourceType = typeof(Locale))]
        public string FirstName { get; set; }

        [Display(Name = "Text_LastName", ResourceType = typeof(Locale))]
        [Required(ErrorMessageResourceName = "Error_LastNameRequired", ErrorMessageResourceType = typeof(Locale))]
        public string LastName { get; set; }

        [Display(Name = "Text_DOB", ResourceType = typeof(Locale))]
        [Required(ErrorMessageResourceName = "Error_DOB", ErrorMessageResourceType = typeof(Locale))]
        public string DateOfBirth { get; set; }

        [Display(Name = "Text_AddressLine1", ResourceType = typeof(Locale))]
        [Required(ErrorMessageResourceName = "Error_Address", ErrorMessageResourceType = typeof(Locale))]
        public string AddressLine1 { get; set; }


        [Display(Name = "Text_AddressLine2", ResourceType = typeof(Locale))]
        public string AddressLine2 { get; set; }


        [Display(Name = "Text_City", ResourceType = typeof(Locale))]
        [Required(ErrorMessageResourceName = "Error_City", ErrorMessageResourceType = typeof(Locale))]
        public string City { get; set; }


        [Display(Name = "Text_Province", ResourceType = typeof(Locale))]
        public string SelectedProvince { get; set; }

        
        public List<SelectListItem> ProvinceList { get; set; }

        [Display(Name = "Text_PostalCode", ResourceType = typeof(Locale))]
        [Required(ErrorMessageResourceName = "Error_PostalCode", ErrorMessageResourceType = typeof(Locale))]
        [RegularExpression("[a-zA-Z][0-9][a-zA-Z] [0-9][a-zA-Z][0-9]", ErrorMessageResourceName = "Error_PostalCodeVal", ErrorMessageResourceType = typeof(Locale))]
        public string PostalCode { get; set; }

        [Display(Name = "Text_Phone", ResourceType = typeof(Locale))]
        [Required(ErrorMessageResourceName = "Error_Phone", ErrorMessageResourceType = typeof(Locale))]
        [RegularExpression(@"^[\d -]+$", ErrorMessageResourceName = "Error_PhoneNumber", ErrorMessageResourceType = typeof(Locale))]
        [StringLength(12, MinimumLength = 12, ErrorMessageResourceName = "Error_PhoneNumber", ErrorMessageResourceType = typeof(Locale))]
        public string Phone { get; set; }

        [Display(Name = "Text_Email", ResourceType = typeof(Locale))]
        [Required(ErrorMessageResourceName = "Error_EmailRequired", ErrorMessageResourceType = typeof(Locale))]
        [EmailAddress(ErrorMessageResourceName = "Error_EmailInvalid", ErrorMessageResourceType = typeof(Locale))]
        public string Email { get; set; }


        [Required(ErrorMessageResourceName = "Error_EventCheckBoxes", ErrorMessageResourceType = typeof(Locale))]
        public List<EventCheckBoxes> EventCheckBoxes { get; set; }


        [Display(Name = "Text_IsFirstTime", ResourceType = typeof(Locale))]
        [Required(ErrorMessageResourceName = "Error_EmailRequired", ErrorMessageResourceType = typeof(Locale))]
        public bool IsFirstTime { get; set; }

        [Required]
        [Range(typeof(bool), "true", "true",ErrorMessageResourceName = "Error_IsAcknowledge", ErrorMessageResourceType =typeof(Locale))]
        [Display(Name = "Text_IsAcknowledge", ResourceType = typeof(Locale))]
        public bool Acknowledge { get; set; }

        [Display(Name = "Text_EmailResult", ResourceType = typeof(Locale))]
        public bool EmailResult { get; set; }

    }
}
