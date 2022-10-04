using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPRO.AddressNS;
using ERPRO.DatabaseNS;

namespace ERPRO.ProductNS
{

    public enum ProductUnit
    {
        Meter,
        Centimeter,
        Quantity,
        Litre
    }

    public class Product
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public Address Location { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }    
        public decimal ProfitInPercentage { get => GetProfitInPercentage();}
        public decimal Profit { get => GetProfit();}
        private int locationID;
        public int LocationID {
            get {return locationID;}
            set {
                Location = Database.Instance.GetAddress(value);
                locationID = value;
            }
        }

        private decimal GetProfit()
        {
           return SellingPrice - PurchasePrice;
        }
        private decimal GetProfitInPercentage()
        { 
            return (PurchasePrice / 100) * GetProfit();
        }
        public string FullAddress { get => Location.FullAddress; }
    }
}