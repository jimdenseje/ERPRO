using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.DatabaseNS;
using TECHCOOL.UI;
using ERPRO.CustomerNS;
using ERPRO.ProductNS;
using ERPRO.Functions.Print;

namespace ERPRO.SalesNS
{
    public class SalesProductPicker : Screen
    {
        ListPage<Product> listPage;

        public List<SalesOrderLine> ProductPicker { get; set; } = new List<SalesOrderLine>();
        public override string Title { get; set; } = "ProductList";

        protected override void Draw()
        {   
            do {
                Clear(this);
                listPage = new ListPage<Product>();
                var products = Database.Instance.GetAllProducts();
                listPage.Add(products);
                listPage.AddColumn("Product Name", nameof(Product.Name), 15);
                listPage.AddColumn("In storage", nameof(Product.Quantity), 12);
                listPage.AddColumn("Purchase price", nameof(Product.PurchasePrice), 15);
                listPage.AddColumn("Selling price", nameof(Product.SellingPrice), 15);
                listPage.AddColumn("Return in percent", nameof(Product.ProfitInPercentage), 18);
                var product = listPage.Select();
                if (product != null)
                {
                    decimal qty = SalesProductQty.get(product.Name, product.Quantity);
                    if (qty > 0)
                    {
                        Product ChosenProduct = Database.Instance.GetProductFromID(product.ItemID);
                        ChosenProduct.Quantity -= qty;
                        Database.Instance.UpdateProduct(ChosenProduct, product.ItemID);
                        var NewOrder = new SalesOrderLine(ChosenProduct);
                        NewOrder.SaleQty = qty;
                        ProductPicker.Add(NewOrder);
                    }
                    Clear(this);
                }
                else
                {
                    Clear(this);
                    Quit();
                }
            } while (Show);
        }
    }
}