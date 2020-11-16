using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class MstItems
    {
        public MstItems()
        {
            TxnCustomerOrderDetails = new HashSet<TxnCustomerOrderDetails>();
            TxnItemFormula = new HashSet<TxnItemFormula>();
            TxnItemFormulaDetails = new HashSet<TxnItemFormulaDetails>();
            TxnItemStock = new HashSet<TxnItemStock>();
            TxnTasks = new HashSet<TxnTasks>();
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public short? UnitId { get; set; }
        public bool? IsProductionRequired { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }

        public virtual MstUnit Unit { get; set; }
        public virtual ICollection<TxnCustomerOrderDetails> TxnCustomerOrderDetails { get; set; }
        public virtual ICollection<TxnItemFormula> TxnItemFormula { get; set; }
        public virtual ICollection<TxnItemFormulaDetails> TxnItemFormulaDetails { get; set; }
        public virtual ICollection<TxnItemStock> TxnItemStock { get; set; }
        public virtual ICollection<TxnTasks> TxnTasks { get; set; }
    }
}
