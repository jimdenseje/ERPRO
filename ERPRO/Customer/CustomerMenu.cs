using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace ERPRO.CustomerNS
{
    public class CustomerMenu : Screen
    {
        public override string Title { get; set; } = "Customer Module";

        protected override void Draw () {
            Menu companyMenu = new Menu();
            companyMenu.Add(new CustomerListPage());
            companyMenu.Start(this);
        }
    }
}