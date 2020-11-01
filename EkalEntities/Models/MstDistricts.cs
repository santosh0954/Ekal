using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class MstDistricts
    {
        public string DistrictCode { get; set; }
        public string DistrictName { get; set; }
        public string StateCode { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual MstStates StateCodeNavigation { get; set; }
    }
}
