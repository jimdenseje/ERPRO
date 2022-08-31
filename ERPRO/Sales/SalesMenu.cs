using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace ERPRO.SalesNS
{
    public class SalesMenu : Screen
    {
        public override string Title { get; set; } = "Sales module";

        protected override void Draw()
        {
            Menu companyMenu = new Menu();
            companyMenu.Add(new SalesListPage());
            companyMenu.Start(this);
        }
    }
}