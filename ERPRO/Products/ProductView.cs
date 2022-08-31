using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHCOOL.UI;
using ERPRO.DatabaseNS;

namespace ERPRO.ProductNS
{
    public class ProductView : Screen
    {
        public override string Title { get; set; } = "View Product";
        private Product product { get; set; }
        public ProductView(Product product) {
            this.product = product;
        }
        
        protected override void Draw()
        {
            Clear(this);
            Console.WriteLine($"|             ID | {product.ItemID}");
            Console.WriteLine($"|           Name | {product.Name}");
            Console.WriteLine($"|    Storage QTY | {product.Quantity}");
            Console.WriteLine($"| Purchase Price | {product.PurchasePrice}");
            Console.WriteLine($"|  Selling Price | {product.SellingPrice}");
            Console.WriteLine($"|         Profit | {product.Profit}");
        }
    }
}