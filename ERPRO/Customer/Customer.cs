using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.AddressNS;

namespace ERPRO.CustomerNS
{
    public class Customer : Person
    {
        public int CustomerNumber { get; set; }
        public DateTime LastPurchase { get; set; }
        public string Road { get => Addresse.Road; set => Addresse.Road = value; }
        public string BuildingNumber { get => Addresse.BuildingNumber; set => Addresse.BuildingNumber = value; }
        public string ZipCode { get => Addresse.ZipCode; set => Addresse.ZipCode = value; }
        public string City { get => Addresse.City; set => Addresse.City = value; }
        public string Country { get => Addresse.Country; set => Addresse.Country = value; }
        public string FullAddress { get => Addresse.FullAddress; }
    }
}