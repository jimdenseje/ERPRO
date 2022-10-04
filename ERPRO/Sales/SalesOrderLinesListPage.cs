using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.DatabaseNS;
using TECHCOOL.UI;
using ERPRO.ProductNS;
using static ERPRO.SalesNS.SalesOrder;
using System.Diagnostics;

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
                
                listPage = new ListPage<SalesOrderLine>();

                if (salesOrder.status == "Created")
                {
                    Console.WriteLine();
                    Console.WriteLine("Press F1 to add SaleOrderLine");
                    Console.WriteLine($"Press F2 to edit SaleOrderLine");
                    Console.WriteLine("Press F5 to delete SaleOrderLine");
                    Console.WriteLine();

                    listPage.AddKey(ConsoleKey.F1, addSaleLineOrder);
                    listPage.AddKey(ConsoleKey.F2, editSaleLineOrder);
                    listPage.AddKey(ConsoleKey.F5, deleteSaleLineOrder);
                }

                if (salesOrder.status != "Packed")
                {
                   Console.WriteLine("Press F3 to edit Status");
                   Console.WriteLine();
                    
                   listPage.AddKey(ConsoleKey.F3, editSaleLineOrderStatus);
                }

                

                topline();

                SalesOrderLine GetNameOfSalesOrderLineProp;
                listPage.AddColumn("Product Name", nameof(GetNameOfSalesOrderLineProp.Name), 18);
                listPage.AddColumn("Items Bought", nameof(GetNameOfSalesOrderLineProp.SaleQty), 14);
                listPage.AddColumn("Price pr Item", nameof(GetNameOfSalesOrderLineProp.SellingPrice), 14);
                listPage.AddColumn("Total Price pr Item", nameof(GetNameOfSalesOrderLineProp.TotalPrice), 20);
                var SalesOrderLines = salesOrder.OrderLines;
                listPage.Add(SalesOrderLines);
                var SalesOrderLine = listPage.Select();

                if (SalesOrderLine != null)
                {
                    //var viewSalesOrderScreen = new SalesView(SalesOrderLine); TODO
                    //Display(viewSalesOrderScreen);TODO
                    Clear(this);
                }
                else
                {
                    Clear(this);
                    Quit();
                    //return; NOT NEEDED HERE JIM
                }

            } while (Show);
        }
        void addSaleLineOrder(SalesOrderLine _)
        {
            //pick a product from a list first WOW 
            SalesProductPicker chooseProduct = new SalesProductPicker();
            Display(chooseProduct);

            foreach (SalesOrderLine pro in chooseProduct.ProductPicker)
            {
                salesOrder.AddSalesOrderLine(pro.Product, pro.SaleQty);
                listPage.Add(pro);
            }

            Database.Instance.UpdateSaleOrder(salesOrder, salesOrder.OrderID);
            
            Clear(this);
            Console.WriteLine();
            Console.WriteLine("Press F1 to add SaleOrderLine");
            Console.WriteLine("Press F2 to edit SaleOrderLine");
            Console.WriteLine("Press F5 to delete SaleOrderLine");
            Console.WriteLine();
            topline();

        }

        void editSaleLineOrderStatus(SalesOrderLine salesOrderLine)
        {
            var viewSalesOrderScreen = new SalesEdit(salesOrder);
            Display(viewSalesOrderScreen);
            Database.Instance.UpdateSaleOrder(salesOrder, salesOrder.OrderID);

            Clear(this);
            Console.WriteLine();
            Console.WriteLine("Press F1 to add SaleOrderLine");
            Console.WriteLine("Press F2 to edit SaleOrderLine");
            Console.WriteLine("Press F5 to delete SaleOrderLine");
            Console.WriteLine();
            topline();
        }

        void editSaleLineOrder(SalesOrderLine salesOrderLine)
        {
            listPage.Remove(salesOrderLine);
            salesOrder.DeleteSalesOrderLine(salesOrderLine);

            decimal oldqty = salesOrderLine.SaleQty;

            Product ChosenProduct = Database.Instance.GetProductFromID(salesOrderLine.Product.ItemID);
            ChosenProduct.Quantity += oldqty;
            Database.Instance.UpdateProduct(ChosenProduct);

            decimal qty = SalesProductQty.get(salesOrderLine.Product.Name, ChosenProduct.Quantity);
            
            salesOrderLine.SaleQty = qty;

            ChosenProduct = Database.Instance.GetProductFromID(salesOrderLine.Product.ItemID);
            ChosenProduct.Quantity -= qty;
            Database.Instance.UpdateProduct(ChosenProduct);

            listPage.Add(salesOrderLine);

            salesOrder.AddSalesOrderLine(salesOrderLine.Product, salesOrderLine.SaleQty);

            Database.Instance.UpdateSaleOrder(salesOrder, salesOrder.OrderID);

            Clear(this);
            Console.WriteLine();
            Console.WriteLine("Press F1 to add SaleOrderLine");
            Console.WriteLine("Press F2 to edit SaleOrderLine");
            Console.WriteLine("Press F5 to delete SaleOrderLine");
            Console.WriteLine();
            topline();
        }

        void deleteSaleLineOrder(SalesOrderLine salesOrderLine)
        {
            //Database.Instance.DeleteSaleOrder(salesOrder, salesOrder.OrderID);

            Product ChosenProduct = Database.Instance.GetProductFromID(salesOrderLine.Product.ItemID);
            ChosenProduct.Quantity += salesOrderLine.SaleQty;
            Database.Instance.UpdateProduct(ChosenProduct);

            salesOrder.DeleteSalesOrderLine(salesOrderLine);
            listPage.Remove(salesOrderLine);

            Clear(this);
            Console.WriteLine();
            Console.WriteLine("Press F1 to add SaleOrderLine");
            Console.WriteLine("Press F2 to edit SaleOrderLine");
            Console.WriteLine("Press F5 to delete SaleOrderLine");
            Console.WriteLine();
            topline();
        }

        void topline()
        {

            //print salesorder propertys
            string[,] ShowProperties = {
                    {"Order ID", salesOrder.OrderID.ToString(), "0"},
                    {"Created", salesOrder.TimeOfCreation.ToString(), "0"},
                    {"Accepted", salesOrder.TimeOfAcceptance.ToString(), "0"},
                    {"Customer ID", salesOrder.CustomerID.ToString(), "0"},
                    {"Customer Name", Database.Instance.GetCustomer(salesOrder.CustomerID).FullName, "0"},
                    {"Order Price", salesOrder.TotalPrice.ToString(), "0"},
                    {"Status", salesOrder.status.ToString(), "0"},
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

        }
    }
}