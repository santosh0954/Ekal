using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class MstBank
    {
        public MstBank()
        {
            TxnVolunteerBankDetails = new HashSet<TxnVolunteerBankDetails>();
        }

        public short BankId { get; set; }
        public string BankName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }

        public virtual ICollection<TxnVolunteerBankDetails> TxnVolunteerBankDetails { get; set; }
    }
}
