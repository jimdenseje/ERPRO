using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.CorporationNS;
using ERPRO.ProductsNS;

namespace ERPRO.DatabaseNS
{
    internal partial class Database
    {
        public static List<Product> ProductList { get; } = new List<Product>();

        public Product GetProductFromID(int id) {
            Product result = null;
            foreach (var products in ProductList)
            {
                if (id == products.ItemID)
                {
                    result = products;
                    break;
                }
            }
            return result;
        }

        public List<Product> GetAllProducts() {
            List<Product> products = new List<Product>();
            foreach (var pro in ProductList) {
                products.Add(pro);
            }
            return ProductList;
        }

        public Product InsertProduct(Product products) {
            ProductList.Add(products);
            return products;
        }

        public void UpdateProduct(Product products, int id) {
            for (int i = 0; i < ProductList.Count; i++) {
                if (ProductList[i].ItemID == id) {
                    ProductList[i] = products;
                    break;
                }
            }
        }

        public void DeleteProduct(Product products, int id) {
            for (int i = 0; i < ProductList.Count; i++) {
                if (ProductList[i].ItemID == id) {
                    ProductList.RemoveAt(i);
                    break;
                }
            }
        }

    }
}