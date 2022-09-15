using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHCOOL.UI;
using ERPRO.Functions.Print;

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

            Console.WriteLine(); //new line

            table.PrintHorizontal(new string[,] {
                    {"Order ID", product.ItemID.ToString()},
                    {"Created", product.Name.ToString()},
                    {"Accepted", product.Quantity.ToString()},
                    {"Customer ID", product.PurchasePrice.ToString()},
                    {"Customer Name", product.SellingPrice.ToString()},
                    {"Order Price", product.Profit.ToString()},
                    {"Status", product.Unit},
                    {"Location", product.FullAddress.ToString()},
            });
        }
    }
}