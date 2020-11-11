using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class VEkai
    {
        public long? SrNo { get; set; }
        public int PrabhagId { get; set; }
        public string Prabhag { get; set; }
        public string Sambhag { get; set; }
        public string Bhag { get; set; }
    }
}
