using System;
using System.Collections.Generic;

namespace MHS.P4.OnlineReferrals.Models.Entities
{
    public partial class Medication
    {
        public Guid MedicationId { get; set; }
        public string Name { get; set; }
        public bool HasNotes { get; set; }
        public string NotesPrompt { get; set; }
        public int VisibilityStatusType { get; set; }
        public int? Position { get; set; }
    }
}
