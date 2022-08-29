using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.SalesNS;

namespace ERPRO.DatabaseNS
{
    internal partial class Database
    {
        public static List<SalesOrder> SalesOrderList { get; } = new List<SalesOrder>();

        public SalesOrder GetSalesorder(int id) {
            SalesOrder result = null;
            foreach (var salesorder in SalesOrderList)
            {
                if (id == salesorder.OrderID) {
                    result = salesorder;
                    break;
                }
            }
            return result;
        }

        public List<SalesOrder> GetSalesOrder() {
            List<SalesOrder> salesorders = new List<SalesOrder>();
            foreach (var saleorder in salesorders) {
                salesorders.Add(saleorder);
            }
            return salesorders;
        }

        public SalesOrder InsertSaleOrder(SalesOrder saleorder) {
            SalesOrderList.Add(saleorder);
            return saleorder;
        }

        public void UpdateSaleOrder(SalesOrder saleorder, int id) {
            for (int i = 0; i < SalesOrderList.Count; i++) {
                if (SalesOrderList[i].OrderID == id) {
                    SalesOrderList[i] = saleorder;
                    break;
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