using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHCOOL.UI;
using ERPRO.DatabaseNS;
using ERPRO.CustomerNS;

namespace ERPRO.CustomerNS
{
    public class CustomerView : Screen
    {
        public override string Title { get; set; } = "View Customer";
        private Customer customer { get; set; }
        public CustomerView(Customer customer) {
            this.customer = customer;
        }
        protected override void Draw()
        {
            Clear(this);
            Console.WriteLine($"|             ID | {customer.ID}");
            Console.WriteLine($"|           Name | {customer.FirstName} {customer.LastName}");
            Console.WriteLine($"|          Email | {customer.Email}");
            Console.WriteLine($"|        Address | {customer.Road} {customer.BuildingNumber}");
            Console.WriteLine($"|   Phone Number | {customer.PhoneNumber}");
            Console.WriteLine($"| CustomerNumber | {customer.CustomerNumber}");

        }
    }
}