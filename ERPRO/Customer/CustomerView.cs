using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHCOOL.UI;
using ERPRO.Functions.Print;

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

            Console.WriteLine(); //new line
            table.PrintHorizontal(new string[,] {
                    {"ID", customer.ID.ToString()},
                    {"Name", customer.FirstName + " " + customer.LastName},
                    {"Email", customer.Email},
                    {"Address",customer.FullAddress},
                    {"Phone Number", customer.PhoneNumber},
                    {"CustomerNumber", customer.CustomerNumber.ToString()},
            });

        }
    }
}