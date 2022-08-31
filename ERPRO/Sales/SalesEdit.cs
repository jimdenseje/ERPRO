using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHCOOL.UI;
using ERPRO.DatabaseNS;
using ERPRO.CorporationNS;

namespace ERPRO.SalesNS
{
    public class SalesEdit : Screen
    {
        public override string Title { get; set; } = "Edit Corporation";
        private SalesOrder salesOrder { get; set; }
        public SalesEdit(SalesOrder salesOrder)
        {
            this.salesOrder = salesOrder;
        }
        protected override void Draw()
        {
            Clear(this);
            Form<SalesOrder> edit = new Form<SalesOrder>();
            edit.TextBox("Order ID", "OrderID");
            edit.TextBox("Time Of Creation", "TimeOfCreation");
            edit.TextBox("Time Of Acceptance", "TimeOfAcceptance");
            edit.TextBox("Person ID", "CustomerID");

            edit.SelectBox("Status", "Status");
            edit.AddOption("Status", "None", CurrencyCode.None);
            edit.AddOption("Status", "Created", CurrencyCode.DKK);
            edit.AddOption("Status", "Confirmed", CurrencyCode.USD);
            edit.AddOption("Status", "Packed", CurrencyCode.EUR);

            edit.Edit(salesOrder);
            Quit();
            Clear(this);
        }
    }
}