using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.ProductNS;
using ERPRO.Functions.Objects;
using ERPRO.CustomerNS;

namespace ERPRO.SalesNS
{


    public class SalesOrder
    {
        public enum Status {
            None,
            Created,
            Confirmed,
            Packed
        }

        public Person person { get; set; }
        public int OrderID { get; set; }
        public DateTime TimeOfCreation { get; set; }
        public DateTime TimeOfAcceptance { get; set; }
        public int CustomerID { get; set; }
        public string status { get; set; }

        //Simons rod
        public string Road { get => person.Addresse.Road; set => person.Addresse.Road = value; }
        public string BuildingNumber { get => person.Addresse.BuildingNumber; set => person.Addresse.BuildingNumber = value; }
        public string ZipCode { get => person.Addresse.ZipCode; set => person.Addresse.ZipCode = value; }
        public string City { get => person.Addresse.City; set => person.Addresse.City = value; }
        public string Country { get => person.Addresse.Country; set => person.Addresse.Country = value; }
        public string LocationName { get => person.Addresse.LocationName; set => person.Addresse.LocationName = value; }
        public string Email { get => person.Email; set => person.Email = value; }
        public string PhoneNumber { get => person.PhoneNumber; set => person.PhoneNumber = value; }

        public List<SalesOrderLine> OrderLines { get; set; } = new List<SalesOrderLine>();

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

        public void AddSalesOrderLine(SalesOrderLine line) {
            OrderLines.Add(line);
        }

        public void DeleteSalesOrderLine(SalesOrderLine salesorderline)
        {
            OrderLines.Remove(salesorderline);
        }

    }

    //Jim made a decision, DRAW LISTPAGE cant list probs in a objects object property and i want to show SaleQty as well
    public class SalesOrderLine 
    {
       public SalesOrderLine(Product product) {
            this.Product = new Product();
            PropMapper<Product, Product>.CopyTo(product, this.Product);
        }

        public SalesOrderLine()  {
            
        }

        public Product Product { get; set; }

        public string Name { get => Product.Name; set => Product.Name = value; }
        public decimal SellingPrice { get => Product.SellingPrice; set => Product.SellingPrice = value; }
       public decimal SaleQty { get; set; }
        public decimal TotalPrice { get => GetTotalPricePrItem(); }
        private decimal GetTotalPricePrItem()
        {
            decimal totalprice = SellingPrice * SaleQty;
            return totalprice;
        }
    }

    //TODO REFRACTOR EVERYTING NO LISTS IN ANY CLASS DOSN'T WORK WITH FRAMEWORK :( ADD SalesOrderLine TO DB (GET SET)

    // public class SalesOrderLine : Product
    // {

    //     public SalesOrderLine(Product product)
    //     {
    //         //REF https://github.com/jitbit/PropMapper
    //         PropMapper<Product, SalesOrderLine>.CopyTo(product, this);
    //     }

    //     public decimal SaleQty { get; set; }

    //     //insted of
    //     /*
    //     public SalesOrderLine(Product product)
    //     {
    //         this.ItemID = product.ItemID;
    //         this.Name = product.Name;
    //         this.Description = product.Description;
    //         this.SellingPrice = product.SellingPrice;
    //         this.PurchasePrice = product.PurchasePrice;
    //         this.Location = product.Location;
    //         this.Quantity = product.Quantity;
    //         this.Unit = product.Unit;
    //     }

    //     I admit it took me some time to figure this out (DAMED OOP), i guess that is how it goes when you set a stuborn producional programmer to create OOP Code
    //     */
    // }

} 