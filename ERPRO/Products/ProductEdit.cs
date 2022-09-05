using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHCOOL.UI;
using ERPRO.DatabaseNS;
using ERPRO.ProductNS;

namespace ERPRO.ProductNS
{
    public class ProductEdit : Screen
    {
        public override string Title { get; set; } = "Edit Product";
        private Product product { get; set; }
        public ProductEdit(Product product)
        {
            this.product = product;
        }
        protected override void Draw()
        {
            Clear(this);
            Form<Product> edit = new Form<Product>();
            edit.TextBox("Name", nameof(product.Name));
            edit.TextBox("Description", nameof(product.Description));
            edit.TextBox("Selling Price", nameof(product.SellingPrice));
            edit.TextBox("Purchase Price", nameof(product.PurchasePrice));
            edit.TextBox("Location", nameof(product.Location));
            edit.TextBox("Quantity", nameof(product.Quantity));

            edit.SelectBox("Unit", nameof(product.Unit));
            edit.AddOption("Unit", "Centimeter", ProductUnit.Centimeter.ToString());
            edit.AddOption("Unit", "Litre", ProductUnit.Litre.ToString());
            edit.AddOption("Unit", "Meter", ProductUnit.Meter.ToString());
            edit.AddOption("Unit", "Quantity", ProductUnit.Quantity.ToString());
            edit.Edit(product);
            Quit();
            Clear(this);
        }
    }
}