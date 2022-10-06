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
            SalesOrder neworder = new SalesOrder();
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
            neworder.person = Database.Instance.GetPerson(chooseCustomer.lastpicker);
            neworder.person.Addresse = Database.Instance.GetAddress(neworder.person.AddresseID);

            SalesProductPicker chooseProduct = new SalesProductPicker();
            Display(chooseProduct);

            neworder.CustomerID = chooseCustomer.lastpicker;
            neworder.OrderLines = chooseProduct.ProductPicker;

            if (neworder.OrderLines.Count == 0)
            {
                Clear(this);
                keyheader.KeyHeader("salesorder");
                return;
            }

            SalesEdit editor = new SalesEdit(neworder);
            Display(editor);

            if (neworder.person.FirstName != "" && neworder.status != null)
            {
                Database.Instance.InsertSaleOrder(neworder);
                listPage.Add(neworder);
            }
            else
            {
                foreach (SalesOrderLine item in neworder.OrderLines)
                {
                    Product ChosenProduct = Database.Instance.GetProductFromID(item.Product.ItemID);
                    ChosenProduct.Quantity += item.SaleQty;
                    Database.Instance.UpdateProduct(ChosenProduct);
                }
            }
            Database.Instance.UpdateSaleOrder(neworder, 0);

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
                    int IdOfProdukt = Database.Instance.GetProductWhereNameAndDescription(item.Product.ItemID);
                    Product ChosenProduct = Database.Instance.GetProductFromID(IdOfProdukt);
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