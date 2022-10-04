using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.PersonNS;
using ERPRO.AddressNS;

namespace ERPRO.CustomerNS
{
    public class Customer : Person
    {
        public int CustomerNumber { get; set; }
        public DateTime LastPurchase { get; set; }

        public string Road { get => Address.Road; set => Address.Road = value; }
        public string BuildingNumber { get => Address.BuildingNumber; set => Address.BuildingNumber = value; }
        public string ZipCode { get => Address.ZipCode; set => Address.ZipCode = value; }
        public string City { get => Address.City; set => Address.City = value; }
        public string Country { get => Address.Country; set => Address.Country = value; }
        public string FullAddress { get => Address.FullAddress; }
    }
}