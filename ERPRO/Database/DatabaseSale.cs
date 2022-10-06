using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.ProductNS;
using ERPRO.SalesNS;

namespace ERPRO.DatabaseNS
{
    internal partial class Database
    {
        public void InsertSaleOrder(SalesOrder saleorder) {
            UpdateSaleOrder(saleorder, 0);
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

                if (order.status != null)
                {
                    switch (order.status)
                    {
                        case "1":
                            order.status = "None";
                            break;
                        case "2":
                            order.status = "Created";
                            break;
                        case "3":
                            order.status = "Confirmed";
                            break;
                        case "4":
                            order.status = "Packed";
                            break;
                        default:
                            break;
                    }
                }

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

                    if (order.status != null)
                    {
                        switch (order.status)
                        {
                            case "1":
                                order.status = "None";
                                break;
                            case "2":
                                order.status = "Created";
                                break;
                            case "3":
                                order.status = "Confirmed";
                                break;
                            case "4":
                                order.status = "Packed";
                                break;
                            default:
                                break;
                        }
                    }

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
            int orderStatus = 1;

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

        public void DeleteSaleOrderLine(int id)
        {

            using (var connection = getConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM SaleOrderLine WHERE SalesOrderLineProductID=" + id;
                int deleted = command.ExecuteNonQuery();
            }

        }
        public void DeleteSaleOrder(SalesOrder saleorder, int id) {

            using (var connection = getConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM SaleOrderLine WHERE SaleOrder=" + id;
                int deleted = command.ExecuteNonQuery();
            }

            using (var connection = getConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM SaleOrder WHERE OrderNumber=" + id;
                int deleted = command.ExecuteNonQuery();
            }
        }
    }
}