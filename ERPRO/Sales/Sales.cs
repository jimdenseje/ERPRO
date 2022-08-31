using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.ProductNS;
using ERPRO.Functions.Objects;
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
        public int CustomerID { get; set; }
        public Status Status { get; set; }
        public List<SalesOrderLine> OrderLines { get; } = new List<SalesOrderLine>();

        public decimal TotalPrice { get => GetTotalPrice(); }
        private decimal GetTotalPrice() {
            decimal totalprice = 0;
            foreach (var product in OrderLines)
            {
                totalprice += product.SellingPrice * product.SaleQty;
            }
            return totalprice;
        }
        public void AddSalesOrderLine(Product product, decimal qty) {
            SalesOrderLine newSalesOrderLine = new SalesOrderLine(product);
            newSalesOrderLine.SaleQty = qty;

            OrderLines.Add(newSalesOrderLine);
        }

    }

    //Jim made a decision, DRAW LISTPAGE cant list probs in a objects object property and i want to show SaleQty as well
    //public class SalesOrderLine 
    //{
    //    public SalesOrderLine(Product product, decimal qty) {
    //        this.Product = product;
    //        this.SaleQty = qty;
    //    }
    //    public Product Product { get; private set; }
    //    public decimal SaleQty { get; set; }
    //}

    //TODO REFRACTOR EVERYTING NO LISTS IN ANY CLASS DOSN'T WORK WITH FRAMEWORK :( ADD SalesOrderLine TO DB (GET SET)

    public class SalesOrderLine : Product
    {

        public SalesOrderLine(Product product)
        {
            //REF https://github.com/jitbit/PropMapper
            PropMapper<Product, SalesOrderLine>.CopyTo(product, this);
        }

        public decimal SaleQty { get; set; }

        //insted of
        /*
        public SalesOrderLine(Product product)
        {
            this.ItemID = product.ItemID;
            this.Name = product.Name;
            this.Description = product.Description;
            this.SellingPrice = product.SellingPrice;
            this.PurchasePrice = product.PurchasePrice;
            this.Location = product.Location;
            this.Quantity = product.Quantity;
            this.Unit = product.Unit;
        }

        I admit it took me some time to figure this out (DAMED OOP), i guess that is how it goes when you set a stuborn producional programmer to create OOP Code
        */
    }

}