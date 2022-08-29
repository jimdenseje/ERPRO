using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPRO.PersonNS;

namespace ERPRO.CustomerNS
{
    public class Customer : Person
    {
        public int CustomerID { get; set; }

        public DateTime LastPurchase { get; set; }

    }
}
