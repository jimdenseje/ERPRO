using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.ProductNS;
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
        public void AddSalesOrderLine(Product product, decimal qty) {
            OrderLines.Add(new SalesOrderLine(product, qty));
        }
    }
    
    public class SalesOrderLine 
    {
        public SalesOrderLine(Product product, decimal qty) {
            this.Product = product;
            this.SaleQty = qty;
        }
        public Product Product { get; private set; }
        public decimal SaleQty { get; set; }
    }
}