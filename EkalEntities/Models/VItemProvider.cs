using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class VItemProvider
    {
        public int ItemProviderId { get; set; }
        public string ProviderType { get; set; }
        public string ProviderTypeName { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string AltMobileNo { get; set; }
        public string EMail { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }
        public string DistrictCode { get; set; }
        public string DistrictName { get; set; }
        public string Tehsil { get; set; }
        public string Pincode { get; set; }
    }
}
