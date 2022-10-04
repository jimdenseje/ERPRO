using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.CustomerNS;
using ERPRO.Functions.Print;
using ERPRO.DatabaseNS;
using ERPRO.ProductNS;
using TECHCOOL.UI;
using System.Xml.Linq;

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
                Console.WriteLine($"Press F1 to add a item");
                Console.WriteLine($"Press F5 to delete a item");
                Console.WriteLine();

                listPage = new ListPage<SalesOrder>();
                listPage.AddKey(ConsoleKey.F1, addSalesOrder);
                listPage.AddKey(ConsoleKey.F5, deleteSalesOrder);
                listPage.AddColumn("Order ID", nameof(SalesOrder.OrderID), 9);
                listPage.AddColumn("Customer ID", nameof(SalesOrder.CustomerID), 12);
                listPage.AddColumn("Total Price", "TotalPrice", 12);
                listPage.AddColumn("Time Of Creation", "TimeOfCreation", 22);
                listPage.AddColumn("Time Of Acceptance", "TimeOfAcceptance", 22);
                listPage.AddColumn("Status", "status", 12);
                var salesOrders = Database.Instance.GetSalesOrder();
                listPage.Add(salesOrders);
                var salesOrder = listPage.Select();
                if (salesOrder != null)
                {
                    var viewSalesOrderScreen = new SalesOrderLinesListPage(salesOrder);
                    Display(viewSalesOrderScreen);
                    Clear(this); 
                }
                else
                {
                    Clear(this); 
                    Quit();
                    
                }

            } while (Show);
        }
        public void addSalesOrder(SalesOrder _)
        {
            Clear(this);

            SalesCustomerPicker chooseCustomer = new SalesCustomerPicker();
            Display(chooseCustomer);

            if (chooseCustomer.lastpicker == 0)
            {
                Clear(this);
                keyheader.KeyHeader("salesorder");
                return;
            }

            SalesProductPicker chooseProduct = new SalesProductPicker();
            Display(chooseProduct);

            SalesOrder newSalesOrder = new SalesOrder();
            newSalesOrder.CustomerID = chooseCustomer.lastpicker;
            newSalesOrder.OrderLines = chooseProduct.ProductPicker;

            if (newSalesOrder.OrderLines.Count == 0)
            {
                Clear(this);
                keyheader.KeyHeader("salesorder");
                return;
            }

            SalesEdit editor = new SalesEdit(newSalesOrder);
            Display(editor);

            if (newSalesOrder.FirstName != "" && newSalesOrder.status != null)
            {
                Database.Instance.InsertSaleOrder(newSalesOrder);
                listPage.Add(newSalesOrder);
            }
            else
            {
                foreach (SalesOrderLine item in newSalesOrder.OrderLines)
                {
                    Product ChosenProduct = Database.Instance.GetProductFromID(item.Product.ItemID);
                    ChosenProduct.Quantity += item.SaleQty;
                    Database.Instance.UpdateProduct(ChosenProduct, item.Product.ItemID);
                }
            }

            Clear(this);
            keyheader.KeyHeader("salesorder");
        }

        void editSalesOrder(SalesOrder salesOrder)
        {
            SalesEdit editor = new SalesEdit(salesOrder);
            Display(editor);
            Database.Instance.UpdateSaleOrder(salesOrder, salesOrder.OrderID);
            Clear(this);
            keyheader.KeyHeader("salesorder");
        }

        void deleteSalesOrder(SalesOrder salesOrder)
        {
            if (salesOrder.status == "Created")
            {
                foreach (SalesOrderLine item in salesOrder.OrderLines)
                {
                    Product ChosenProduct = Database.Instance.GetProductFromID(item.Product.ItemID);
                    ChosenProduct.Quantity += item.SaleQty;
                    Database.Instance.UpdateProduct(ChosenProduct, item.Product.ItemID);
                }
            }

            Database.Instance.DeleteSaleOrder(salesOrder, salesOrder.OrderID);
            listPage.Remove(salesOrder);
            Clear(this);
            keyheader.KeyHeader("salesorder");
        }
    }
}