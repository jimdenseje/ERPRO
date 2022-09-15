using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHCOOL.UI;
using ERPRO.ProductNS;


    public class ProductMenu : Screen
    {
        public override string Title { get; set; } = "Product module";

        protected override void Draw () {
            Menu companyMenu = new Menu();
            companyMenu.Add(new ProductListPage());
            companyMenu.Start(this);
        }
    }
