using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MHS.P4.Language;

namespace MHS.P4.OnlineReferrals.Models
{
    public class PocketModel : GeneralModel
    {
        [Display(Name = "TestRequested2Weeks", ResourceType = typeof(Locale))]
        public bool TestRequested2Weeks { get; set; }


        [Display(Name = "TestRepeatInconclusive", ResourceType = typeof(Locale))]
        public bool TestRepeatInconclusive { get; set; }

        public string TestRequested { get; set; }


        [Display(Name = "ReqDate", ResourceType = typeof(Locale))]
        public DateTime ReqDate { get; set; }
    }
}
