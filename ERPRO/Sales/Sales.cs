using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPRO.SalesNS
{
    public enum Status {
        None,
        Created,
        Confirmed,
        Packed
    }
    public class SalesOrder
    {
        public int OrderID { get; set; }
        public DateTime TimeOfCreation { get; set; }
        public DateTime TimeOfAcceptance { get; set; }
        public int PersonID { get; set; }
        public Status Status { get; set; }
        public List<string> OrderLines { get; set; }
        public decimal Total { get; private set; }
    }


}