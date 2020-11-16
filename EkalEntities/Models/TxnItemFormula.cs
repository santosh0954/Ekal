using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class TxnItemFormula
    {
        public TxnItemFormula()
        {
            TxnItemFormulaDetails = new HashSet<TxnItemFormulaDetails>();
        }

        public int ItemFormulaId { get; set; }
        public int? ItemId { get; set; }
        public string FormulaName { get; set; }
        public decimal? ForQty { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }

        public virtual MstItems Item { get; set; }
        public virtual ICollection<TxnItemFormulaDetails> TxnItemFormulaDetails { get; set; }
    }
}
