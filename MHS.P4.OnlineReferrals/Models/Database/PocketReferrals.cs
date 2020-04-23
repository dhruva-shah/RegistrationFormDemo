using System;
using System.Collections.Generic;

namespace MHS.P4.OnlineReferrals.Models.Database
{
    public partial class PocketReferrals
    {
        public int ReferralId { get; set; }
        public string ReferringPhysician { get; set; }
        public string ReferringPhysicianFax { get; set; }
        public string ReferringPhysicianCpso { get; set; }
        public string InterpretingPhysician { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public DateTime? Dob { get; set; }
        public string PatientPhone { get; set; }
        public string PatientHealthCardNum { get; set; }
        public string PatientHealthCardVersion { get; set; }
        public string PatientCcname { get; set; }
        public string PatientCcfax { get; set; }
        public string PatientReasonForReferral { get; set; }
        public string PatientMedications { get; set; }
        public bool? IsPacemaker { get; set; }
        public bool? IsDefibrillator { get; set; }
        public bool? IsTest2Weeks { get; set; }
        public bool? IsTestInconclusive { get; set; }
        public DateTime? DateCreated { get; set; }
        public string InsuranceType { get; set; }
        public string TestRequested { get; set; }
        public int? TestType { get; set; }
        public string ConfirmationEmail { get; set; }
        public bool? EmailResult { get; set; }

        public virtual TestType TestTypeNavigation { get; set; }
    }
}
