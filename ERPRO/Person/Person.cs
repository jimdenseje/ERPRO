using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPRO.PersonNS
{
    public class Person
    {

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => GetFullName(); }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        private string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }


}
