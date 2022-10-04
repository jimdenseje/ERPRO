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
                Console.WriteLine($"Press F1 to add a Sales Order");
                Console.WriteLine($"Press F5 to delete a Sales Order");
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
                if(salesOrders.Count == 0) {
                    salesOrders.Add(new SalesOrder());
                }
                listPage.Add(salesOrders);
                SalesOrder salesOrder = null;
                try{salesOrder = listPage.Select();}
                catch(ArgumentOutOfRangeException){
                    salesOrder = new SalesOrder();
                }
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
            Person person = new Person();
            Clear(this);

            SalesCustomerPicker chooseCustomer = new SalesCustomerPicker();
            Display(chooseCustomer);

            if (chooseCustomer.lastpicker == 0)
            {
                Clear(this);
                keyheader.KeyHeader("salesorder");
                return;
            }

            // person = Database.Instance.GetPerson(chooseCustomer.lastpicker);
            _.person = Database.Instance.GetPerson(chooseCustomer.lastpicker);
            _.person.Addresse = Database.Instance.GetAddress(_.person.AddresseID);

            SalesProductPicker chooseProduct = new SalesProductPicker();
            Display(chooseProduct);

            _.CustomerID = chooseCustomer.lastpicker;
            _.OrderLines = chooseProduct.ProductPicker;

            if (_.OrderLines.Count == 0)
            {
                Clear(this);
                keyheader.KeyHeader("salesorder");
                return;
            }

            SalesEdit editor = new SalesEdit(_);
            Display(editor);

            if (_.person.FirstName != "" && _.status != null)
            {
                Database.Instance.InsertSaleOrder(_);
                listPage.Add(_);
            }
            else
            {
                foreach (SalesOrderLine item in _.OrderLines)
                {
                    Product ChosenProduct = Database.Instance.GetProductFromID(item.Product.ItemID);
                    ChosenProduct.Quantity += item.SaleQty;
                    Database.Instance.UpdateProduct(ChosenProduct);
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
                    Database.Instance.UpdateProduct(ChosenProduct);
                }
            }

            Database.Instance.DeleteSaleOrder(salesOrder, salesOrder.OrderID);
            listPage.Remove(salesOrder);
            Clear(this);
            keyheader.KeyHeader("salesorder");
        }
    }
}