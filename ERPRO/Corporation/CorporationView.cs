using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHCOOL.UI;
using ERPRO.DatabaseNS;

namespace ERPRO.CorporationNS
{
    public class CorporationView : Screen
    {
        public override string Title { get; set; } = "View Corporation";
        private Corporation corporation { get; set; }
        public CorporationView(Corporation corporation) {
            this.corporation = corporation;
        }
        protected override void Draw()
        {
            Clear(this);
            Console.WriteLine($"|       ID | {corporation.ID}");
            Console.WriteLine($"|     Name | {corporation.CorporationName}");
            Console.WriteLine($"|  Country | {corporation.Country}");
            Console.WriteLine($"|     City | {corporation.CityName}");
            Console.WriteLine($"| Zip Code | {corporation.Zipcode}");
            Console.WriteLine($"|     Road | {corporation.RoadName}");
            Console.WriteLine($"| Building | {corporation.BuildingNumber}");
            Console.WriteLine($"| Currency | {corporation.CurrencyCode}");
        }
    }
}