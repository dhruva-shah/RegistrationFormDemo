using System;
using System.Collections.Generic;

namespace RegistrationFormDemo.Models.Database
{
    public partial class RegistrationEvent
    {
        public int RegistrationEventId { get; set; }
        public int RegistrationId { get; set; }
        public int EventId { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual Events Event { get; set; }
        public virtual Registrations Registration { get; set; }
    }
}
