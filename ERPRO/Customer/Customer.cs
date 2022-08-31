using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPRO.CustomerNS
{
    public class Customer : Person
    {
        public int ID { get; set; }
        public int CustomerNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime LastPurchase { get; set; }
    }
}