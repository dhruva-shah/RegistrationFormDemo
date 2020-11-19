using System;
using System.Collections.Generic;

namespace RegistrationFormDemo.Models.Database
{
    public partial class Registrations
    {
        public Registrations()
        {
            RegistrationEvent = new HashSet<RegistrationEvent>();
        }

        public int RegistrationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int Province { get; set; }
        public string PostalCode { get; set; }
        public DateTime? Dob { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool? IsFirstTime { get; set; }
        public bool? SendConfirmationEmail { get; set; }
        public DateTime? DateRegistered { get; set; }

        public virtual ICollection<RegistrationEvent> RegistrationEvent { get; set; }
    }
}
