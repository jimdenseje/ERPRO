using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPRO.ProductsNS
{
    public class Product
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public string OBJLocation { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }    
       
        
        
        public decimal Profit()
        {
           return SellingPrice - PurchasePrice;
        }
        public decimal ProfitInPercentage()
        { 
            return (PurchasePrice / 100) * Profit();
        }
    }

}
