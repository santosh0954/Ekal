using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class MstBank
    {
        public int BankId { get; set; }
        public string BankName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
    }
}
