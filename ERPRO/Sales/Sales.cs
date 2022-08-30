using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.ProducktsNS;
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
        public List<SalesOrderLine> OrderLines { get; } = new List<SalesOrderLine>();
        public decimal GetTotalPrice() {
            decimal totalprice = 0;
            foreach (var product in OrderLines)
            {
                totalprice += product.Product.SellingPrice * product.SaleQty;
            }
            return totalprice;
        }
        public void AddSalesOrderLine(Produckt product, decimal qty) {
            OrderLines.Add(new SalesOrderLine(product, qty));
        }
    }
    
    public class SalesOrderLine 
    {
        public SalesOrderLine(Produckt product, decimal qty) {
            this.Product = product;
            this.SaleQty = qty;
        }
        public Produckt Product { get; private set; }
        public decimal SaleQty { get; set; }
    }
}