using MHS.P4.Language;
using MHS.P4.OnlineReferrals.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MHS.P4.OnlineReferrals.Models
{
    public class MedicationCheckBoxes
    {
        /// <summary>
        /// Gets and sets the  id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets and sets the name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets and sets whether there are notes
        /// </summary>
        public bool HasNotes { get; set; }

        [NotMapped]
        public bool AllowEmptyOther
        {
            get
            {
                return (this.HasNotes && this.IsChecked);
            }
        }
        /// <summary>
        /// Gets and sets the  notes
        /// </summary>
        [RequiredIf("AllowEmptyOther", true, ErrorMessageResourceName = "Error_OtherNeeded", ErrorMessageResourceType = typeof(Locale))]
        public string Notes { get; set; }
        /// <summary>
        /// Gets and sets whether selected
        /// </summary>
        /// 
        public bool IsChecked { get; set; }
    }
}
