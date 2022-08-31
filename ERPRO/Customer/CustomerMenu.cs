using ERPRO.CustomerNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace ERPRO.CustomerNS
{
    public class CustomerMenu : Screen
    {
        public override string Title { get; set; } = "Customermodule";

        protected override void Draw () {
            Menu customerMenu = new Menu();
            customerMenu.Add(new CustomerListPage());
            customerMenu.Start(this);
        }
    }
}