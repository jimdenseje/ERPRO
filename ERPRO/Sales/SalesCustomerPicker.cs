using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.DatabaseNS;
using TECHCOOL.UI;
using ERPRO.CustomerNS;

namespace ERPRO.SalesNS
{
    public class SalesCustomerPicker : Screen
    {
        ListPage<Customer> listPage;

        public int lastpicker { get; set; }

        public override string Title { get; set; } = "Customers";

        protected override void Draw()
        {   
            do {
                Clear(this);

                Console.WriteLine();
                Console.WriteLine("Press F1 to add a new Customer");
                Console.WriteLine();

                Customer customer;
                listPage = new ListPage<Customer>();
                listPage.AddKey(ConsoleKey.F1, addCustomer);
                listPage.AddColumn("Full Name", nameof(customer.FullName), 20);
                listPage.AddColumn("Address", nameof(customer.Address), 25);
                //listPage.AddColumn("Last Purchase", nameof(customer.LastPurchase), 25);
                var customers = Database.Instance.GetCustomer();
                listPage.Add(customers);
                customer = listPage.Select();
                if (customer != null) {
                    lastpicker = customer.ID;
                    Quit();
                } else {
                    Quit();
                    return;
                }
            } while (Show);
        }
        void addCustomer(Customer _) {
            Customer newCustomer = new Customer();
            CustomerEdit editor = new CustomerEdit(newCustomer);
            Display(editor);
            if(newCustomer.FirstName != null) {
                Database.Instance.InsertCustomer(newCustomer);
                listPage.Add(newCustomer);
            }
        }
    }
}