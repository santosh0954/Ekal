using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class TxnVolunteerBankDetails
    {
        public int VolunteerBankDetailsId { get; set; }
        public int? VolunteerId { get; set; }
        public short? BankId { get; set; }
        public string AccountNo { get; set; }
        public string Ifsc { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
    }
}
