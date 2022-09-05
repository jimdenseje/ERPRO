using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHCOOL.UI;
using ERPRO.DatabaseNS;
using ERPRO.ProductNS;
using ERPRO.Functions.Print;

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
            Console.WriteLine(); //new line

            table.PrintHorizontal(new string[,] {
                    {"ID", corporation.ID.ToString()},
                    {"Name", corporation.CorporationName},
                    {"Country", corporation.Country},
                    {"City", corporation.CityName},
                    {"Zip Code", corporation.Zipcode},
                    {"Road", corporation.RoadName},
                    {"Building", corporation.BuildingNumber},
                    {"Currency", corporation.CurrencyCode.ToString()},
            });

        }
    }
}