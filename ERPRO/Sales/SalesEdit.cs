using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHCOOL.UI;
using ERPRO.DatabaseNS;
using ERPRO.CustomerNS;
using ERPRO.ProductNS;
using ERPRO.PersonNS;

namespace ERPRO.SalesNS
{
    public class SalesEdit : Screen
    {
        public override string Title { get; set; } = "Add SalesOrder";
        private SalesOrder salesOrder { get; set; }
        private Product product { get; set; }


        public SalesEdit(SalesOrder salesOrder)
        {
            this.salesOrder = salesOrder; 
        }
        protected override void Draw()
        {
            Clear(this);
            Form<SalesOrder> edit = new Form<SalesOrder>();
            /*edit.TextBox("Order ID", "OrderID");
            edit.TextBox("Time Of Creation", "TimeOfCreation");
            edit.TextBox("Time Of Acceptance", "TimeOfAcceptance");*/
            //edit.TextBox("Customer ID", "CustomerID");

            edit.TextBox("Road", nameof(Person.Address.Road));
            edit.TextBox("BuildingNumber", nameof(Person.Address.BuildingNumber));
            edit.TextBox("Zip Code", nameof(Person.Address.ZipCode));
            edit.TextBox("City", nameof(Person.Address.City));
            edit.TextBox("Email", nameof(Person.Email));
            edit.TextBox("PhoneNumber", nameof(Person.PhoneNumber));

            edit.SelectBox("Status", "status");
            edit.AddOption("Status", "None", nameof(SalesOrder.Status.None));
            edit.AddOption("Status", "Created", nameof(SalesOrder.Status.Created));
            edit.AddOption("Status", "Confirmed", nameof(SalesOrder.Status.Confirmed));
            edit.AddOption("Status", "Packed", nameof(SalesOrder.Status.Packed));

            edit.Edit(salesOrder);
            Quit();
            Clear(this);
        }
    }
}