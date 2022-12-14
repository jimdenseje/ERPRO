using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.DatabaseNS;
using TECHCOOL.UI;
using ERPRO.Functions.Print;

namespace ERPRO.CustomerNS
{
    public class CustomerListPage : Screen
    {
        ListPage<Customer> listPage;
        public override string Title { get; set; } = "Customers";
        protected override void Draw()
        {   
            do {
                Clear(this);
                keyheader.KeyHeader("customer");
                listPage = new ListPage<Customer>();
                listPage.AddKey(ConsoleKey.F1, addCustomer);
                listPage.AddKey(ConsoleKey.F2, editCustomer);
                listPage.AddKey(ConsoleKey.F5, deleteCustomer);
                listPage.AddColumn("Customer Number", nameof(Customer.CustomerNumber), 20);
                listPage.AddColumn("Full Name", nameof(Customer.FullName), 20);
                listPage.AddColumn("Phone Number", nameof(Customer.PhoneNumber), 20);
                listPage.AddColumn("E-Mail", nameof(Customer.Email), 25);
                var customers = Database.Instance.GetCustomer();
                listPage.Add(customers);
                var customer = listPage.Select();
                if (customer != null) {
                    var viewCustomerScreen = new CustomerView(customer);
                    Screen.Display(viewCustomerScreen);
                    Clear(this);
                    keyheader.KeyHeader("customer"); //added here to fix header when going back from view
                }
                else
                {
                    Clear(this);
                    Quit();
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

                // var customers = Database.Instance.GetCustomer();
                // listPage.Add(customers);
            }
            Clear(this);
            keyheader.KeyHeader("customer"); //added here to fix header when going back from edit view
        }

        void editCustomer(Customer customer) {
            CustomerEdit editor = new CustomerEdit(customer);
            Display(editor);
            Database.Instance.UpdateCustomer(customer);
            Clear(this);
            keyheader.KeyHeader("customer"); //added here to fix header when going back from edit view
        }

         void deleteCustomer(Customer customer) {
            Database.Instance.DeleteCustomer(customer);
            listPage.Remove(customer);
            Clear(this);
            keyheader.KeyHeader("customer"); //added here to fix header when going back from edit view
        }
    }
}