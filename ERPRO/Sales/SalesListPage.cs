using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.Functions.Print;
using ERPRO.DatabaseNS;
using TECHCOOL.UI;

namespace ERPRO.SalesNS
{
    public class SalesListPage : Screen
    {
        ListPage<SalesOrder> listPage;
        public override string Title { get; set; } = "SalesOrders";
        public bool refresh;
        protected override void Draw()
        {
            do
            {
                Clear(this);
                keyheader.KeyHeader("salesorder");
                listPage = new ListPage<SalesOrder>();
                listPage.AddKey(ConsoleKey.F1, addSalesOrder);
                listPage.AddKey(ConsoleKey.F2, editSalesOrder);
                listPage.AddKey(ConsoleKey.F5, deleteSalesOrder);
                listPage.AddColumn("Order ID", "OrderID", 10);
                listPage.AddColumn("Customer ID", "CustomerID", 12);
                listPage.AddColumn("Total Price", "TotalPrice", 12);
                listPage.AddColumn("Time Of Creation", "TimeOfCreation", 22);
                listPage.AddColumn("Time Of Acceptance", "TimeOfAcceptance", 22);
                listPage.AddColumn("Status", "Status", 12);
                var salesOrders = Database.Instance.GetSalesOrder();
                listPage.Add(salesOrders);
                var salesOrder = listPage.Select();
                if (salesOrder != null)
                {
                    var viewSalesOrderScreen = new SalesOrderLinesListPage(salesOrder);
                    Display(viewSalesOrderScreen);
                    Clear(this); //FIX BY JIM
                }
                else
                {
                    Clear(this); //FIX BY JIM
                    Quit();
                    //return; NOT NEEDED HERE JIM
                }

            } while (Show);
        }
        void addSalesOrder(SalesOrder _)
        {
            SalesOrder newSalesOrder = new SalesOrder();
            SalesEdit editor = new SalesEdit(newSalesOrder);
            Display(editor);
            if (newSalesOrder.CustomerID != 0)
            {
                Database.Instance.InsertSaleOrder(newSalesOrder);
                listPage.Add(newSalesOrder);
            }
        }

        void editSalesOrder(SalesOrder salesOrder)
        {
            SalesEdit editor = new SalesEdit(salesOrder);
            Display(editor);
            Database.Instance.UpdateSaleOrder(salesOrder, salesOrder.OrderID);
        }

        void deleteSalesOrder(SalesOrder salesOrder)
        {
            Database.Instance.DeleteSaleOrder(salesOrder, salesOrder.OrderID);
            listPage.Remove(salesOrder);
        }
    }
}