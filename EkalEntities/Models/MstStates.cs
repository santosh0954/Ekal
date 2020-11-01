using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class MstStates
    {
        public MstStates()
        {
            MstDistricts = new HashSet<MstDistricts>();
        }

        public string StateCode { get; set; }
        public string StateName { get; set; }
        public string ShortName { get; set; }
        public string Tin { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<MstDistricts> MstDistricts { get; set; }
    }
}
