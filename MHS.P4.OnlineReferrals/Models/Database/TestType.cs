using System;
using System.Collections.Generic;

namespace MHS.P4.OnlineReferrals.Models.Database
{
    public partial class TestType
    {
        public TestType()
        {
            PocketReferrals = new HashSet<PocketReferrals>();
        }

        public int TestId { get; set; }
        public string TestName { get; set; }

        public virtual ICollection<PocketReferrals> PocketReferrals { get; set; }
    }
}
