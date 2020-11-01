using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class MstVolunteerType
    {
        public short VolunteerTypeId { get; set; }
        public string VolunteerType { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedId { get; set; }
    }
}
