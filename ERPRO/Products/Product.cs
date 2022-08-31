using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPRO.AddressNS;

namespace ERPRO.ProductNS
{
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
       
        private decimal GetProfit()
        {
           return SellingPrice - PurchasePrice;
        }

        private decimal GetProfitInPercentage()
        { 
            return (PurchasePrice / 100) * GetProfit();
        }
    }

}
