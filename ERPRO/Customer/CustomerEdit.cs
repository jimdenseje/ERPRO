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
            edit.TextBox("First name", nameof(customer.FirstName));
            edit.TextBox("Last name", nameof(customer.LastName));
            edit.TextBox("Road name", nameof(customer.Road));
            edit.TextBox("Builing number", nameof(customer.BuildingNumber));
            edit.TextBox("Zipcode", nameof(customer.ZipCode));
            edit.TextBox("City", nameof(customer.City));
            edit.TextBox("Phone number", nameof(customer.PhoneNumber));
            edit.TextBox("Email", nameof(customer.Email));
            edit.Edit(customer);
            Database.Instance.UpdateCustomer(customer);
            Quit();
            Clear(this);
        }
    }
}