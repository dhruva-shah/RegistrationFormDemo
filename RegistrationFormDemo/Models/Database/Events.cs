using System;
using System.Collections.Generic;

namespace RegistrationFormDemo.Models.Database
{
    public partial class Events
    {
        public Events()
        {
            RegistrationEvent = new HashSet<RegistrationEvent>();
        }

        public int EventId { get; set; }
        public string EventName { get; set; }
        public int? Position { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<RegistrationEvent> RegistrationEvent { get; set; }
    }
}
