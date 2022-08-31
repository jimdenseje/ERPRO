using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.DatabaseNS;
using TECHCOOL.UI;

namespace ERPRO.ProductNS
{
    public class ProductListPage : Screen
    {
        ListPage<Product> listPage;
        public override string Title { get; set; } = "Products";
        protected override void Draw()
        {   
            do {
                Clear(this);
                listPage = new ListPage<Product>();
                var products = Database.Instance.GetAllProducts();
                listPage.Add(products);
                listPage.AddColumn("Product ID", nameof(Product.ItemID), 20);
                listPage.AddColumn("Product Name", nameof(Product.Name), 20);
                listPage.AddColumn("In storage", nameof(Product.Quantity), 20);
                listPage.AddColumn("Purchase price", nameof(Product.PurchasePrice), 20);
                listPage.AddColumn("Selling price", nameof(Product.SellingPrice), 20);
                listPage.AddColumn("Return in percent", nameof(Product.ProfitInPercentage), 20);
                var product = listPage.Select();
                if (product != null) {
                    var viewProductScreen = new ProductView(product);
                    Screen.Display(viewProductScreen);
                } else {
                    Quit();
                    return;
                }
            } while (Show);
        }
    }
}