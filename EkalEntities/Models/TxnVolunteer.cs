using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class TxnVolunteer
    {
        public TxnVolunteer()
        {
            TxnVolunteerBankDetails = new HashSet<TxnVolunteerBankDetails>();
        }

        public int VolunteerId { get; set; }
        public short? VolunteerTypeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string AltMobileNo { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string AadhaarNo { get; set; }
        public int? EkaiId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Tehsil { get; set; }
        public string DistrictCode { get; set; }
        public string StateCode { get; set; }
        public string Pincode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }

        public virtual MstEkai Ekai { get; set; }
        public virtual MstVolunteerType VolunteerType { get; set; }
        public virtual ICollection<TxnVolunteerBankDetails> TxnVolunteerBankDetails { get; set; }
    }
}
