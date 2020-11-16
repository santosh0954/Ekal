using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class TxnItemFormulaDetails
    {
        public int ItemFormulaDetailsId { get; set; }
        public int? ItemFormulaId { get; set; }
        public int? SubItemId { get; set; }
        public decimal? Qty { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }

        public virtual TxnItemFormula ItemFormula { get; set; }
        public virtual MstItems SubItem { get; set; }
    }
}
