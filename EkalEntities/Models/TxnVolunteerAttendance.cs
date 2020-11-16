using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class TxnVolunteerAttendance
    {
        public int VolunteerAttendanceDetails { get; set; }
        public int? VolunteerId { get; set; }
        public DateTime? AttDate { get; set; }
        public bool? IsPresent { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }

        public virtual TxnVolunteer Volunteer { get; set; }
    }
}
