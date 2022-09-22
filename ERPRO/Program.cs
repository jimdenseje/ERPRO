using TECHCOOL.UI;
using ERPRO.CorporationNS;
using ERPRO.DatabaseNS;
using ERPRO.MainNS;
using ERPRO.CustomerNS;
using ERPRO.ProductNS;
using ERPRO.AddressNS;
using ERPRO.SalesNS;

//Customer Database instance::
Database.Instance.InsertCustomer(new Customer
{
    ID = 1,
    FirstName = "Jim",
    LastName = "Damgaard",
    PhoneNumber = "+4550533174",
    Email = "jimdenseje@gmail.com",
    CustomerNumber = 12645,
    LastPurchase = DateTime.Now,
    Road = "Damsvej",
    BuildingNumber = "32",
    ZipCode = "6100",
    City = "Haderslev",
    Country = "Denmark",
});

Database.Instance.InsertCustomer(new Customer
{
    ID = 2,
    FirstName = "jonas",
    LastName = "luuk",
    PhoneNumber = "+456456443",
    Email = "jfd@gmail.com",
    CustomerNumber = 12645,
    LastPurchase = DateTime.Now,
    Road = "Damsvej",
    BuildingNumber = "32",
    ZipCode = "6100",
    City = "Haderslev",
    Country = "Denmark",
});
//Customer Database instance ending::

//Product Database instance::
Database.Instance.InsertProduct(new Product(1) {
    ItemID = 1,
    Name = "Bold",
    Description = "En rund orange og sort bold",
    SellingPrice = 59.99m,
    PurchasePrice = 39.99m,
    Quantity = 100,
    Unit = "Indefinite",
});
Database.Instance.InsertProduct(new Product(1) {
    ItemID = 2,
    Name = "Basketbold",
    Description = "En rund orange og sort bold",
    SellingPrice = 59.99m,
    PurchasePrice = 39.99m,
    Quantity = 100,
    Unit = "Indefinite",
});

Database.Instance.InsertProduct(new Product(1)
{
    ItemID = 3,
    Name = "Bacon",
    Description = "fdsf",
    SellingPrice = 100,
    PurchasePrice = 60,
    Quantity = 2,
    Unit = "fdgh",
});

Database.Instance.InsertProduct(new Product(1)
{
    ItemID = 4,
    Name = "Kage",
    Description = "fdsf",
    SellingPrice = 20,
    PurchasePrice = 14,
    Quantity = 2,
    Unit = "fdgh",

});

Database.Instance.InsertProduct(new Product(1)
{
    ItemID = 5,
    Name = "Æble",
    Description = "fdsf",
    SellingPrice = 10,
    PurchasePrice = 6,
    Quantity = 2,
    Unit = "fdgh",
});

SalesOrder mySaleOrder = new SalesOrder
{
    OrderID = 1,
    TimeOfCreation = DateTime.Now,
    TimeOfAcceptance = DateTime.Now,
    Status = Status.Confirmed,
    CustomerID = 1,
};
mySaleOrder.AddSalesOrderLine(Database.Instance.GetProductFromID(1), 2);
Database.Instance.InsertSaleOrder(mySaleOrder);

mySaleOrder = new SalesOrder
{
    OrderID = 2,
    TimeOfCreation = DateTime.Now,
    TimeOfAcceptance = DateTime.Now,
    Status = Status.Packed,
    CustomerID = 2,
};
mySaleOrder.AddSalesOrderLine(Database.Instance.GetProductFromID(2), 1);
mySaleOrder.AddSalesOrderLine(Database.Instance.GetProductFromID(3), 10);
Database.Instance.InsertSaleOrder(mySaleOrder);

/* Debug data For Address
Address testaddress = new Address();
testaddress.BuildingNumber = "A45";

Produckt testproduckt = new Produckt(); 
testproduckt.ItemID = 1;
testproduckt.Name = "testproduckt";
testproduckt.Location = testaddress;*/

string intro = @" .----------------.  .----------------.  .----------------.  .----------------.  .----------------. 
| .--------------. || .--------------. || .--------------. || .--------------. || .--------------. |
| |  _________   | || |  _______     | || |   ______     | || |  _______     | || |     ____     | |
| | |_   ___  |  | || | |_   __ \    | || |  |_   __ \   | || | |_   __ \    | || |   .'    `.   | |
| |   | |_  \_|  | || |   | |__) |   | || |    | |__) |  | || |   | |__) |   | || |  /  .--.  \  | |
| |   |  _|  _   | || |   |  __ /    | || |    |  ___/   | || |   |  __ /    | || |  | |    | |  | |
| |  _| |___/ |  | || |  _| |  \ \_  | || |   _| |_      | || |  _| |  \ \_  | || |  \  `--'  /  | |
| | |_________|  | || | |____| |___| | || |  |_____|     | || | |____| |___| | || |   `.____.'   | |
| |              | || |              | || |              | || |              | || |              | |
| '--------------' || '--------------' || '--------------' || '--------------' || '--------------' |
 '----------------'  '----------------'  '----------------'  '----------------'  '----------------' 
  - Made by GRP4 - Jim, Marcus & Tobias";

Console.Clear();
Console.CursorVisible = false;
Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.WriteLine(intro);
Console.ForegroundColor = ConsoleColor.White;
Console.ReadKey();
Console.CursorVisible = false; //fix for rezising

Screen.Display(new Mainmenu());