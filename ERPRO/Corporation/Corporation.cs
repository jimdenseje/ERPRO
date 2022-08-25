using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPRO.Corporation
{
    public class Corporation
    {
        public int ID { get; private set; }
        public string CorporationName { get; set; }
        public string RoadName { get; set; }
        public string BuildingNumber { get; set; }
        public string Zipcode { get; set; }
        public string CityName { get; set; }
        public string Country { get; set; }
        public string CurrencyCode { get; set; }   
    }
}