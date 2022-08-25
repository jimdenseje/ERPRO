using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace ERPRO.Main
{
    public class Mainmenu : Screen
    {
        public override string Title { get; set; } = "Main menu";

        protected override void Draw () {
            Console.WriteLine("Welcome to ERPRO, your favourite ERP system.");
        }
    }
}