using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class VItemFormulaDetails
    {
        public int ItemFormulaDetailsId { get; set; }
        public int? ItemFormulaId { get; set; }
        public int? SubItemId { get; set; }
        public string ItemName { get; set; }
        public decimal? Qty { get; set; }
        public string Unit { get; set; }
    }
}
