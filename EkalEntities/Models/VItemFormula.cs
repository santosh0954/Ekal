using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class VItemFormula
    {
        public int ItemFormulaId { get; set; }
        public string FormulaName { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal? ForQty { get; set; }
    }
}
