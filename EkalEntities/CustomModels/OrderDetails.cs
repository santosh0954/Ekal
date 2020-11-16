using System;
using System.Collections.Generic;
using System.Text;

namespace EkalEntities.CustomModels
{
    public class OrderDetails
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public decimal Rate { get; set; }
        public int Qty { get; set; }
        public decimal Amount { get; set; }
    }
}
