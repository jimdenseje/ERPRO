using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.ProductNS;

namespace ERPRO.DatabaseNS
{
    internal partial class Database
    {
        public static List<Product> ProductList { get; } = new List<Product>();

        public Product GetProductFromID(int id) {
            Product result = null;
            foreach (var product in ProductList)
            {
                if (id == product.ItemID)
                {
                    result = product;
                    break;
                }
            }
            return result;
        }

        public List<Product> GetAllProducts() {
            List<Product> products = new List<Product>();
            foreach (var product in ProductList) {
                products.Add(product);
            }
            return products;
        }

        public Product InsertProduct(Product product) {
            ProductList.Add(product);
            return product;
        }

        public void UpdateProduct(Product product, int id) {
            for (int i = 0; i < ProductList.Count; i++) {
                if (ProductList[i].ItemID == id) {
                    ProductList[i] = product;
                    break;
                }
            }
        }

        public void DeleteProduct(Product product, int id) {
            for (int i = 0; i < ProductList.Count; i++) {
                if (ProductList[i].ItemID == id) {
                    ProductList.RemoveAt(i);
                    break;
                }
            }
        }

    }
}