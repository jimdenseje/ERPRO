using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.DatabaseNS;
using TECHCOOL.UI;
using ERPRO.CustomerNS;
using ERPRO.ProductNS;

namespace ERPRO.SalesNS
{
    public class SalesProductPicker : Screen
    {
        ListPage<Product> listPage;

        public int ProductPicker { get; set; }

        public override string Title { get; set; } = "Customers";

        protected override void Draw()
        {   
            do {
                Clear(this);

                Console.WriteLine();
                Console.WriteLine("Press F1 to add a new Customer");
                Console.WriteLine();

                Product product;
                Form<Product> listpage = new Form<Product>();
                listpage.SelectBox("Status", "status");
                listpage.AddOption("Status", "None", nameof(SalesOrder.Status.None));
                listpage.AddOption("Status", "Created", nameof(SalesOrder.Status.Created));
                listpage.AddOption("Status", "Confirmed", nameof(SalesOrder.Status.Confirmed));
                listpage.AddOption("Status", "Packed", nameof(SalesOrder.Status.Packed));
                //listPage.AddColumn("Last Purchase", nameof(customer.LastPurchase), 25);
                var products = Database.Instance.GetAllProducts();
                listPage.Add(products);
                product = listPage.Select();
                if (product != null) {
                    ProductPicker = product.ItemID;
                    Quit();
                } else {
                    Quit();
                    return;
                }
            } while (Show);
        }
        void addProduct(Product _) {
            Product newProduct = new Product();
            ProductEdit editor = new ProductEdit(newProduct);
            Display(editor);
            if(newCustomer.FirstName != null) {
                Database.Instance.InsertCustomer(newCustomer);
                listPage.Add(newCustomer);
            }
        }
    }
}