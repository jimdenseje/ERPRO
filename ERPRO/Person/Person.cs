using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPRO.CustomerNS;
using ERPRO.AddressNS;

namespace ERPRO.PersonNS
{
    public class Person : Address
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => GetFullName(); }
        public Address Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
     


        private string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        protected Person () {
            Address = new Address();
        }
    }


}
