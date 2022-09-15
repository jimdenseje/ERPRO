using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.CustomerNS;
using ERPRO.DatabaseNS;
using ERPRO.ProductNS;
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

                Console.WriteLine();
                Console.WriteLine("Press F1 to add an item");
                Console.WriteLine("Press F2 to edit an item");
                Console.WriteLine("Press F5 to delete an item");
                Console.WriteLine();

                //Console.CursorVisible = false;
                listPage = new ListPage<SalesOrder>();
                listPage.AddKey(ConsoleKey.F1, addSalesOrder);
                listPage.AddKey(ConsoleKey.F2, editSalesOrder);
                listPage.AddKey(ConsoleKey.F5, deleteSalesOrder);
                listPage.AddColumn("Customer ID", nameof(SalesOrder.CustomerID), 12);
                listPage.AddColumn("Total Price", "TotalPrice", 12);
                listPage.AddColumn("Time Of Creation", "TimeOfCreation", 22);
                listPage.AddColumn("Time Of Acceptance", "TimeOfAcceptance", 22);
                listPage.AddColumn("Status", "status", 12);
                var salesOrders = Database.Instance.GetSalesOrder();
                listPage.Add(salesOrders);
                var salesOrder = listPage.Select();
                //Console.CursorVisible = true;
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
            Clear(this);

            SalesCustomerPicker chooseCustomer = new SalesCustomerPicker();
            Display(chooseCustomer);


            SalesProductPicker chooseProduct = new SalesProductPicker();
            Display(chooseProduct);

            /*
            Console.WriteLine("Edit Exesisten Customer");
            Console.WriteLine("Edit New Customer");
            string key = Console.ReadLine();
            if (key == "1")
            {

            }
            if (key == "2")
            {

            }
            */


            SalesOrder newSalesOrder = new SalesOrder();
            newSalesOrder.CustomerID = chooseCustomer.lastpicker;
            SalesEdit editor = new SalesEdit(newSalesOrder);
            Display(editor);

                if (newSalesOrder.FirstName != "")
                {
                    Database.Instance.InsertSaleOrder(newSalesOrder);
                    listPage.Add(newSalesOrder);
                }



            SalesOrder newProduct = new SalesOrder();
            newProduct.CustomerID = chooseProduct.ProductPicker;
            SalesEdit salesEdit = new SalesEdit(newProduct);
            Display(salesEdit);

            if (newProduct.FirstName != "")
            {
                Database.Instance.InsertSaleOrder(newProduct);
                listPage.Add(newProduct);
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