using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class TxnTasks
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int? ForItemId { get; set; }
        public decimal? ForQty { get; set; }
        public string WorkType { get; set; }
        public DateTime? EstimatedStartDate { get; set; }
        public DateTime? EstimatedEndDate { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }

        public virtual MstItems ForItem { get; set; }
    }
}
