using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.SalesNS;

namespace ERPRO.DatabaseNS
{
    internal partial class Database
    {
        // public static List<SalesOrder> SalesOrderList { get; } = new List<SalesOrder>();

        List<SalesOrder> SalesOrderList = new List<SalesOrder>();

        public void InsertSaleOrder(SalesOrder saleorder) {
            SalesOrderList.Add(saleorder);
        }

        public SalesOrder GetSalesorder(int id) {
            SalesOrder order = new SalesOrder();
            using (var connection = getConnection()){
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM SaleOrder WHERE OrderNumber=" + id;
                var reader = command.ExecuteReader();
                reader.Read();
                order.OrderID = reader.GetInt32(0);
                order.TimeOfCreation = reader.GetDateTime(1);
                order.TimeOfAcceptance = reader.GetDateTime(2);
                order.CustomerID = reader.GetInt32(3);
                order.status = reader.GetString(4);




            }
            return order;
        }

        public List<SalesOrder> GetSalesOrder() {
            List<SalesOrder> salesorders = new List<SalesOrder>();
            using (var connection = getConnection()){
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM SaleOrder";
                var reader = command.ExecuteReader();

                while(reader.Read()){
                    SalesOrder order = new SalesOrder();
                    order.OrderID = reader.GetInt32(0);
                    order.TimeOfCreation = reader.GetDateTime(1);
                    order.TimeOfAcceptance = reader.GetDateTime(2);
                    order.CustomerID = reader.GetInt32(3);
                    order.status = reader.GetByte(4).ToString();
                    salesorders.Add(order);
                }
                reader.Close();

                int i = 0;
                foreach (var order in salesorders)
                {  
                    command.CommandText = "SELECT SalesOrderLineProductID, QTY FROM SaleOrderLine WHERE SaleOrder =" + order.OrderID;
                    var reader2 = command.ExecuteReader();
                    List<SalesOrderLine> orderlines = new List<SalesOrderLine>();
                    while(reader2.Read()){
                        SalesOrderLine line = new SalesOrderLine(Database.Instance.GetSalesProductFromID(reader2.GetInt32(0)));
                        line.SaleQty = reader2.GetDecimal(1);
                        orderlines.Add(line);
                    }
                    salesorders[i].OrderLines = orderlines;
                    reader2.Close();
                    i++;
                }
                return salesorders;
            }
            
        }

        public void UpdateSaleOrder(SalesOrder saleorder, int id) {
            int orderStatus = 0;

            if(saleorder.status != null){
                switch (saleorder.status)
                {
                    case "None":
                        orderStatus = 1;
                        break;
                    case "Created":
                        orderStatus = 2;
                    break;
                    case "Confirmed":
                        orderStatus = 3;
                        break;
                    case "Packed":
                        orderStatus = 4;
                        break;
                    default:
                        break;
                }
            }
            using (var connection = getConnection()){
                var command = connection.CreateCommand();
            if (saleorder.OrderID == null || saleorder.OrderID == 0){
                command.CommandText = 
                @$"INSERT INTO SaleOrder (PersonID, Status, TimeOfCreation, TimeOfAcceptance)
                VALUES ('{saleorder.CustomerID}', '{orderStatus}', GETDATE(), GETDATE());
                ";
                command.ExecuteNonQuery();
                //Getting the ID from initialy created salesorder
                var saleorderid = connection.CreateCommand();
                saleorderid.CommandText = "SELECT CAST(SCOPE_IDENTITY() AS INT)";
                var saleorderidreader = saleorderid.ExecuteReader();
                saleorderidreader.Read();
                saleorder.OrderID = saleorderidreader.GetInt32(0);
                saleorderidreader.Close();

                command.CommandText = 
                @$"UPDATE Customer
                SET LastPurchase = GETDATE()
                WHERE ID = '{saleorder.CustomerID}'
                ";
                command.ExecuteNonQuery();


                //SalesOrderLineProduct
                int salesOrderLineProductID = 0;
                foreach (var orderline in saleorder.OrderLines)
                {
                    command.CommandText = 
                    @$"INSERT INTO SalesOrderLineProduct (ItemName, ItemDescription, SellingPrice, PurchasePrice, StorageID, QTY, UNIT)
                    VALUES ('{orderline.Product.Name}', '{orderline.Product.Description}', '{orderline.Product.SellingPrice}', '{orderline.Product.PurchasePrice}', '{orderline.Product.LocationID}', '{orderline.SaleQty}', '{orderline.Product.Unit}');
                    ";
                    command.ExecuteNonQuery();

                    //Getting the ID from initialy created SalesOrderLineProduct
                    var salesorderlineproductid = connection.CreateCommand();
                    salesorderlineproductid.CommandText = "SELECT CAST(SCOPE_IDENTITY() AS INT)";
                    var salesorderlineproductidreader = salesorderlineproductid.ExecuteReader();
                    salesorderlineproductidreader.Read();
                    salesOrderLineProductID = salesorderlineproductidreader.GetInt32(0);
                    salesorderlineproductidreader.Close();

                    //Sales order line
                    command.CommandText = 
                    @$"INSERT INTO SaleOrderLine (SaleOrder, SalesOrderLineProductID, QTY)
                    VALUES ('{saleorder.OrderID}', '{salesOrderLineProductID}', '{orderline.SaleQty}');
                    ";
                    command.ExecuteNonQuery();
                }
            } else {
                
                
            }
        }
        }

        public void DeleteSaleOrder(SalesOrder saleorder, int id) {
            for (int i = 0; i < SalesOrderList.Count; i++) {
                if (SalesOrderList[i].OrderID == id) {
                    SalesOrderList.RemoveAt(i);
                    break;
                }
            }
        }
    }
}