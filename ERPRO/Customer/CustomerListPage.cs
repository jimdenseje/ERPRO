using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.DatabaseNS;
using TECHCOOL.UI;

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
                listPage = new ListPage<Customer>();
                listPage.AddColumn("FirstName", "FirstName", 30);
                listPage.AddColumn("PhoneNumber", "PhoneNumber", 15);
                var Customers = Database.Instance.GetCustomer();
                listPage.Add(Customers);
                var Customer = listPage.Select();

                Quit();
                return;

            } while (Show);
        }
    }
}