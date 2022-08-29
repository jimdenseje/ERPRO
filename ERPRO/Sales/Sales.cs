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
    public enum Storage {
        Local,
        External
    }

    public class SalesOrder
    {
        public int OrderID { get; set; }
        public DateTime TimeOfCreation { get; set; }
        public DateTime TimeOfAcceptance { get; set; }
        public int PersonID { get; set; }
        public Status Status { get; set; }
        public List<SalesOrderLine> OrderLines { get; } = new List<SalesOrderLine>();
        public decimal GetTotalPrice() {
            decimal totalprice = 0;
            foreach (var product in OrderLines)
            {
                totalprice += product.ProductSellingPrice;
            }
            return totalprice;
        }
    }
    public class SalesOrderLine 
    {
        public SalesOrder SalesOrder { get; set; }
        int ProductItemID { get; set; }
        string ProductName { get; set; }
        public decimal ProductSellingPrice { get; set; }
        public Storage Storage { get; set; }
        public decimal SaleQty { get; set; }
    }
}