using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.DatabaseNS;
using TECHCOOL.UI;
using ERPRO.ProductNS;

namespace ERPRO.SalesNS
{
    public class SalesOrderLinesListPage : Screen
    {
        private SalesOrder salesOrder { get; set; }
        public SalesOrderLinesListPage(SalesOrder salesOrder)
        {
            this.salesOrder = salesOrder;
        }

        ListPage<SalesOrderLine> listPage;
        public override string Title { get; set; } = "SalesOrder";
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

                //print salesorder propertys
                string[,] ShowProperties = {
                    {"Order ID", salesOrder.OrderID.ToString(), "0"},
                    {"Created", salesOrder.TimeOfCreation.ToString(), "0"},
                    {"Accepted", salesOrder.TimeOfAcceptance.ToString(), "0"},
                    {"Customer ID", salesOrder.CustomerID.ToString(), "0"},
                    {"Customer Name", Database.Instance.GetCustomer(salesOrder.CustomerID).FullName, "0"},
                    {"Order Price", salesOrder.TotalPrice.ToString(), "0"},
                    {"Status", salesOrder.Status.ToString(), "0"},
                };

                //if chars lengt in ShowProperties[?, 0 OR 1] > ShowProperties[?, 2] Edit ShowProperties[?, 2] to match max string width
                for (int i = 0; i < ShowProperties.GetLength(0); i++)
                {
                    if (ShowProperties[i, 0].Length > System.Convert.ToInt32(ShowProperties[i, 2]))
                    {
                        ShowProperties[i, 2] = (ShowProperties[i, 0].Length).ToString();
                    }

                    if (ShowProperties[i, 1].Length > System.Convert.ToInt32(ShowProperties[i, 2]))
                    {
                        ShowProperties[i, 2] = (ShowProperties[i, 1].Length).ToString();
                    }

                }

                //add top line on table
                Console.ForegroundColor = ConsoleColor.Cyan;
                int linelengt = 2;
                for (int i = 0; i < ShowProperties.GetLength(0); i++)
                {
                    linelengt = linelengt + System.Convert.ToInt32(ShowProperties[i, 2]) + 3;
                }
                Console.WriteLine("=== Order Details ".PadRight(linelengt, '='));
                Console.ForegroundColor = ConsoleColor.White;

                //add keys
                for (int i = 0; i < ShowProperties.GetLength(0); i++)
                {
                    Console.Write("| " + ShowProperties[i, 0].PadRight(System.Convert.ToInt32(ShowProperties[i, 2])) + " ");
                }
                Console.WriteLine(" |");

                //add middle line on table
                for (int i = 0; i < ShowProperties.GetLength(0); i++)
                {
                    Console.Write("".PadRight(System.Convert.ToInt32(ShowProperties[i, 2]) + 3, '-'));
                }
                Console.WriteLine("--");

                //add values
                for (int i = 0; i < ShowProperties.GetLength(0); i++)
                {
                    Console.Write("| " + ShowProperties[i, 1].PadRight(System.Convert.ToInt32(ShowProperties[i, 2])) + " ");
                }
                Console.WriteLine(" |");

                //add bottom line on table
                for (int i = 0; i < ShowProperties.GetLength(0); i++)
                {
                    Console.Write("".PadRight(System.Convert.ToInt32(ShowProperties[i, 2]) + 3, '-'));
                }
                Console.WriteLine("--");

                Console.WriteLine(""); //new line before showing list


                //SHOW LIST
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=== Order Lines  ".PadRight(linelengt, '=')); //give the select list a name sorry unable to edit select list
                                                                                 //without editing libery so didn't make it pretty
                Console.ForegroundColor = ConsoleColor.White;

                listPage = new ListPage<SalesOrderLine>();
                listPage.AddKey(ConsoleKey.F1, addSaleLineOrder);
                listPage.AddKey(ConsoleKey.F2, editSaleLineOrder);
                listPage.AddKey(ConsoleKey.F5, deleteSaleLineOrder);
                listPage.AddColumn("Product Name", "Name", 20);
                listPage.AddColumn("Items Bought", "SaleQty", 12);
                var SalesOrderLines = salesOrder.OrderLines;
                listPage.Add(SalesOrderLines);
                var SalesOrderLine = listPage.Select();

                if (SalesOrderLine != null)
                {
                    //var viewSalesOrderScreen = new SalesView(SalesOrderLine); TODO
                    //Display(viewSalesOrderScreen);TODO
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
        void addSaleLineOrder(SalesOrderLine salesOrderLine)
        {
            //pick a product from a list first WOW TODO
            Product product = Database.Instance.GetProductFromID(1); //TODO

            SalesOrderLine newSalesOrderLine = new SalesOrderLine(product);
            SalesOrderLinesEdit editor = new SalesOrderLinesEdit(newSalesOrderLine);
            Display(editor);
            if (newSalesOrderLine.SaleQty != 0)
            {
                //Database.Instance.UpdateSaleOrder(newSalesOrderLine, salesOrder.ItemID); TODO
                listPage.Add(newSalesOrderLine);
            }
        }

        void editSaleLineOrder(SalesOrderLine salesOrderLine)
        {
            SalesOrderLinesEdit editor = new SalesOrderLinesEdit(salesOrderLine);
            Display(editor);
            //Database.Instance.UpdateSaleOrder(salesOrder, salesOrder.OrderID); TODO
        }

        void deleteSaleLineOrder(SalesOrderLine salesOrderLine)
        {
            //Database.Instance.DeleteSaleOrder(salesOrder, salesOrder.OrderID); TODO
            listPage.Remove(salesOrderLine);
        }
    }
}