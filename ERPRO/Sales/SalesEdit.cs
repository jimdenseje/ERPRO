using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHCOOL.UI;
using ERPRO.DatabaseNS;
using ERPRO.CustomerNS;
using ERPRO.ProductNS;

namespace ERPRO.SalesNS
{
    public class SalesEdit : Screen
    {
        public override string Title { get; set; } = "Add SalesOrder";
        private SalesOrder salesOrder { get; set; }
        
        //Skal have fat i en specific person
        private Person person { get; set; }
        public List<SalesOrderLine> OrderLines { get; set; }
        private Product product { get; set; }

        public SalesEdit(SalesOrder salesOrder)
        {
            this.salesOrder = salesOrder;
        }
        protected override void Draw()
        {
            Clear(this);
            Form<SalesOrder> edit = new Form<SalesOrder>();

            edit.TextBox("Road", nameof(salesOrder.person.Addresse.Road));
            edit.TextBox("BuildingNumber", nameof(salesOrder.person.Addresse.BuildingNumber));
            edit.TextBox("Zip Code", nameof(salesOrder.person.Addresse.ZipCode));
            edit.TextBox("City", nameof(salesOrder.person.Addresse.City));
            edit.TextBox("Email", nameof(salesOrder.person.Email));
            edit.TextBox("PhoneNumber", nameof(salesOrder.person.PhoneNumber));

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