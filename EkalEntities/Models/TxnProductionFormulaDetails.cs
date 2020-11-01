using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class TxnProductionFormulaDetails
    {
        public int ProductionFormulaDetailsId { get; set; }
        public int? ProductionFormulaId { get; set; }
        public int? SubItemId { get; set; }
        public decimal? Qty { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
    }
}
