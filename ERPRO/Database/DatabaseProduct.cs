using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.ProductNS;

namespace ERPRO.DatabaseNS
{
    internal partial class Database
    {
        List<Product> ProductList = new List<Product>();

        public void InsertProduct(Product product) {
            ProductList.Add(product);
        }


        public Product GetProductFromID(int id) {
            Product product = new Product();
            using (var connection = getConnection()){
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Product WHERE ID=" + id;
                var reader = command.ExecuteReader();
                reader.Read();
                try{product.ItemID = reader.GetInt32(0);}
                catch(InvalidOperationException e){
                    return new Product();
                }
                product.Name = reader.GetString(1);
                product.Description = reader.GetString(2);
                product.SellingPrice = reader.GetDecimal(3);
                product.PurchasePrice = reader.GetDecimal(4);
                product.LocationID = reader.GetInt32(5);
                product.Quantity = reader.GetDecimal(6);
                product.Unit = reader.GetString(7);
            };
            return product;
        }

        public Product GetSalesProductFromID(int id) {
            Product product = new Product();
            using (var connection = getConnection()){
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM SalesOrderLineProduct WHERE ID=" + id;
                var reader = command.ExecuteReader();
                reader.Read();
                try{product.ItemID = reader.GetInt32(0);}
                catch(InvalidOperationException e){
                    return new Product();
                }
                product.Name = reader.GetString(1);
                product.Description = reader.GetString(2);
                product.SellingPrice = reader.GetDecimal(3);
                product.PurchasePrice = reader.GetDecimal(4);
                product.LocationID = reader.GetInt32(5);
                product.Quantity = reader.GetDecimal(6);
                product.Unit = reader.GetString(7);
            };
            return product;
        }

        public List<Product> GetAllProducts() {
            List<Product> products = new List<Product>();
            using (var connection = getConnection()){
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Product";
                var reader = command.ExecuteReader();

                while(reader.Read()){
                    Product product = new Product();
                    product.ItemID = reader.GetInt32(0);
                    product.Name = reader.GetString(1);
                    product.Description = reader.GetString(2);
                    product.SellingPrice = reader.GetDecimal(3);
                    product.PurchasePrice = reader.GetDecimal(4);
                    product.LocationID = reader.GetInt32(5);
                    product.Quantity = reader.GetDecimal(6);
                    product.Unit = reader.GetString(7);
                    products.Add(product);
                }
                reader.Close();
            }
            return products;
        }


        public void UpdateProduct(Product product) {
            using (var connection = getConnection()){
                var command = connection.CreateCommand();
                if (product.ItemID == null || product.ItemID == 0){
                    command.CommandText = 
                    @$"
                    INSERT INTO Product (ItemName, ItemDescription, SellingPrice, PurchasePrice, StorageID, QTY, UNIT)
                    VALUES ('{product.Name}', '{product.Description}', '{product.SellingPrice}', '{product.PurchasePrice}', '{product.LocationID}', '{product.Quantity}', '{product.Unit}');
                    ";
                    command.ExecuteNonQuery();

                    //Getting the ID from initialy created product
                    var productid = connection.CreateCommand();
                    productid.CommandText = $"SELECT ID FROM Product WHERE ItemDescription = '{product.Description}'";
                    var productidreader = productid.ExecuteReader();
                    productidreader.Read();
                    product.ItemID = productidreader.GetInt32(0);
                    productidreader.Close();
                } else {
                    command.CommandText =
                    @$"UPDATE Product
                    SET ItemName = '{product.Name}', ItemDescription = '{product.Description}', SellingPrice = '{product.SellingPrice}', PurchasePrice = '{product.PurchasePrice}', StorageID = '{product.LocationID}', QTY = '{product.Quantity}', UNIT = '{product.Unit}'
                    WHERE ID = {product.ItemID};
                    ";
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool DeleteProduct(Product product) {
            using (var connection = getConnection()) {
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Product WHERE ID=" + product.ItemID;
                int deleted = command.ExecuteNonQuery();
                return deleted > 0;
            }
        }

    }
}