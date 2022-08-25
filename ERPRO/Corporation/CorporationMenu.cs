using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace ERPRO.CorporationNS
{
    public class CorporationMenu : Screen
    {
        public override string Title { get; set; } = "Corporationmodule";

        protected override void Draw () {
            Menu companyMenu = new Menu();
            companyMenu.Add(new CorporationListPage());
            companyMenu.Start(this);
        }
    }
}