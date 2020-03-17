using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MHS.P4.Language;

namespace MHS.P4.OnlineReferrals.Models
{
    public class PatchModel : GeneralModel
    {
        [Display(Name = "PatchPutOn", ResourceType = typeof(Locale))]
        [Required(ErrorMessageResourceName = "Error_PathPutOn", ErrorMessageResourceType = typeof(Locale))]
        public DateTime PatchPutOn { get; set; }


        [Display(Name = "SerialNum", ResourceType = typeof(Locale))]
        [Required(ErrorMessageResourceName = "Error_SerialNum", ErrorMessageResourceType = typeof(Locale))]
        public string SerialNum { get; set; }
    }
}
