using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHCOOL.UI;
using ERPRO.DatabaseNS;

namespace ERPRO.CustomerNS
{
    public class CustomerEdit : Screen
    {
        public override string Title { get; set; } = "Edit Customer";
        private Customer customer { get; set; }
        public CustomerEdit(Customer customer) {
            this.customer = customer;
        }
        protected override void Draw()
        {
            Clear(this);
            Form<Customer> edit = new Form<Customer>();
            edit.TextBox("First name", "FirstName");
            edit.TextBox("Last name", "LastName");
            edit.TextBox("Phone number", "PhoneNumber");
            edit.TextBox("Address", "Address");
            edit.TextBox("Email", "Email");
            edit.Edit(customer);
            Quit();
            Clear(this);
        }
    }
}