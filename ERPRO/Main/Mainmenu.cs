using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHCOOL.UI;
using ERPRO.CorporationNS;
using ERPRO.CustomerNS;
namespace ERPRO.MainNS
{
    public class Mainmenu : Screen
    {
        public override string Title { get; set; } = "Main menu";

        protected override void Draw () {
            Menu mainMenu = new Menu();
            mainMenu.Add(new CorporationMenu());
            mainMenu.Add(new CustomerMenu());
            mainMenu.Start(this);
        }
    }
}