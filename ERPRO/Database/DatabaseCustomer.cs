using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.CustomerNS;

namespace ERPRO.DatabaseNS
{
    internal partial class Database
    {
        public static List<Customer> CustomerList { get; } = new List<Customer>();

        public Customer GetCustomer(int id) {
            Customer result = null;
            foreach (var Customer in CustomerList)
            {
                if (id == Customer.ID) {
                    result = Customer;
                    break;
                }
            }
            return result;
        }

        public List<Customer> GetCustomer() {
            List<Customer> Customers = new List<Customer>();
            foreach (var crp in CustomerList) {
                Customers.Add(crp);
            }
            return Customers;
        }

        public Customer InsertCustomer(Customer Customer) {
            CustomerList.Add(Customer);
            return Customer;
        }

        public void UpdateCustomer(Customer Customer, int id) {
            for (int i = 0; i < CustomerList.Count; i++) {
                if (CustomerList[i].ID == id) {
                    CustomerList[i] = Customer;
                    break;
                }
            }
        }

        public void DeleteCustomer(Customer Customer, int id) {
            for (int i = 0; i < CustomerList.Count; i++) {
                if (CustomerList[i].ID == id) {
                    CustomerList.RemoveAt(i);
                    break;
                }
            }
        }
    }
}