using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPRO.AddressNS
{
    public class Address
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string BuildingNumber { get; set; }
        public string Road { get; set; }
        public string LocationName { get; set; }
        public string FullAddress { get => GetFullAddress(); }
        private string GetFullAddress () {
            string fulladdress = $"{Road} {BuildingNumber}, {ZipCode}, {City} {Country}";
            return fulladdress;
        }
    }
}
