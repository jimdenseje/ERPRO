using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHCOOL.UI;
using ERPRO.DatabaseNS;

namespace ERPRO.CorporationNS
{
    public class CorporationEdit : Screen
    {
        public override string Title { get; set; } = "Edit Corporation";
        private Corporation corporation { get; set; }
        public CorporationEdit(Corporation corporation) {
            this.corporation = corporation;
        }
        protected override void Draw()
        {
            Clear(this);
            Form<Corporation> edit = new Form<Corporation>();
            edit.TextBox("Corporation name", "CorporationName");
            edit.TextBox("Road name", "RoadName");
            edit.SelectBox("Currency code", "CurrencyCode");
            edit.AddOption("Currency code", "None", CurrencyCode.None);
            edit.AddOption("Currency code", "DKK", CurrencyCode.DKK);
            edit.AddOption("Currency code", "USD", CurrencyCode.USD);
            edit.AddOption("Currency code", "EUR", CurrencyCode.EUR);
            
            edit.Edit(corporation);
            Quit();
        }
    }
}