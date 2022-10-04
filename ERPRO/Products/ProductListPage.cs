using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.Functions.Print;
using ERPRO.DatabaseNS;
using TECHCOOL.UI;

namespace ERPRO.ProductNS
{
    public class ProductListPage : Screen
    {
        ListPage<Product> listPage;

        public int ProductPicker { get; set; }

        public override string Title { get; set; } = "Products";
        protected override void Draw()
        {   
            do {
                Clear(this);
                keyheader.KeyHeader("product");
                listPage = new ListPage<Product>();
                var products = Database.Instance.GetAllProducts();
                listPage.Add(products);
                listPage.AddKey(ConsoleKey.F1, addProduct);
                listPage.AddKey(ConsoleKey.F2, editProduct);
                listPage.AddKey(ConsoleKey.F5, deleteProduct);
                listPage.AddColumn("Product ID", nameof(Product.ItemID), 10);
                listPage.AddColumn("Product Name", nameof(Product.Name), 15);
                listPage.AddColumn("In storage", nameof(Product.Quantity), 12);
                listPage.AddColumn("Purchase price", nameof(Product.PurchasePrice), 15);
                listPage.AddColumn("Selling price", nameof(Product.SellingPrice), 15);
                listPage.AddColumn("Return in percent", nameof(Product.ProfitInPercentage), 18);
                var product = listPage.Select();
                if (product != null) {
                    ProductPicker = product.ItemID;
                    var viewProductScreen = new ProductView(product);
                    Screen.Display(viewProductScreen);

                    Clear(this); 
                    keyheader.KeyHeader("product"); //added here to fix header when going back from view
                } else
                {
                    Clear(this); 
                    Quit();
                }
            } while (Show);
        }
        void addProduct(Product _)
        {
            Product newProduct = new Product();
            ProductEdit editor = new ProductEdit(newProduct);
            Display(editor);
            if (newProduct.Name != null)
            {
                Database.Instance.InsertProduct(newProduct);
                listPage.Add(newProduct);
            }

            Clear(this);
            keyheader.KeyHeader("product"); //added here to fix header when going back from edit view
        }

        void editProduct(Product product)
        {
            ProductEdit editor = new ProductEdit(product);
            Display(editor);
            Database.Instance.UpdateProduct(product);
            Clear(this); 
            keyheader.KeyHeader("product"); //added here to fix header when going back from edit view
        }

        void deleteProduct(Product product)
        {
            Database.Instance.DeleteProduct(product);
            listPage.Remove(product);
            Clear(this); 
            keyheader.KeyHeader("product"); //added here to fix header when going back from edit view
        }
    }
}