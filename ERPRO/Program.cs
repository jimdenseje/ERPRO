using TECHCOOL.UI;
using ERPRO.CorporationNS;
using ERPRO.DatabaseNS;
using ERPRO.MainNS;
using ERPRO.CustomerNS;
using ERPRO.ProductNS;
using ERPRO.AddressNS;
using ERPRO.SalesNS;

//Corporation database instances::
Database.Instance.InsertCorporation(new Corporation {
    ID = 1,
    CorporationName = "Fisketorvet",
    Country = "Denmark",
    CityName = "Copenhagen",
    Zipcode = "3600",
    RoadName = "Kongensvej",
    BuildingNumber = "A1",
    CurrencyCode = CurrencyCode.DKK
});

Database.Instance.InsertCorporation(new Corporation {
    ID = 2,
    CorporationName = "Jensens Fiskebiks",
    Country = "Denmark",
    CityName = "Copenhagen",
    Zipcode = "3600",
    RoadName = "Kongensvej",
    BuildingNumber = "A1",
    CurrencyCode = CurrencyCode.DKK
});

Database.Instance.InsertCorporation(new Corporation {
    ID = 3,
    CorporationName = "Skabsrokken",
    Country = "Denmark",
    CityName = "Copenhagen",
    Zipcode = "3600",
    RoadName = "Kongensvej",
    BuildingNumber = "A1",
    CurrencyCode = CurrencyCode.DKK
});
//Corporation Database instance ending::

//Customer Database instance::
Address jimsaddress = new Address
{
    ZipCode = "9640",
    Road = "Statinonsvej",
    BuildingNumber = "8",
    City = "Farsø",
    Country = "Denmark",
};
    Database.Instance.InsertCustomer(new Customer
{
    ID = 1,
    FirstName = "Jim",
    LastName = "Damgaard",
    PhoneNumber = "+4550533174",
    Email = "jimdenseje@gmail.com",
    CustomerNumber = 1264532,
    LastPurchase = DateTime.Now,
    Address = jimsaddress,
});
//Customer Database instance ending::

//Product Database instance::
Database.Instance.InsertProduct(new Product {
    ItemID = 1,
    Name = "Bold",
    Description = "En rund orange og sort bold",
    SellingPrice = 59.99m,
    PurchasePrice = 39.99m,
    Quantity = 100,
    Unit = "Indefinite"
});
Database.Instance.InsertProduct(new Product {
    ItemID = 2,
    Name = "Basketbold",
    Description = "En rund orange og sort bold",
    SellingPrice = 59.99m,
    PurchasePrice = 39.99m,
    Quantity = 100,
    Unit = "Indefinite"
});

Database.Instance.InsertProduct(new Product
{
    ItemID = 3,
    Name = "Bacon",
    Description = "fdsf",
    SellingPrice = 100,
    PurchasePrice = 60,
    Quantity = 2,
    Unit = "fdgh",
});

Database.Instance.InsertProduct(new Product
{
    ItemID = 4,
    Name = "Kage",
    Description = "fdsf",
    SellingPrice = 20,
    PurchasePrice = 14,
    Quantity = 2,
    Unit = "fdgh",
});

Database.Instance.InsertProduct(new Product
{
    ItemID = 5,
    Name = "Æble",
    Description = "fdsf",
    SellingPrice = 10,
    PurchasePrice = 6,
    Quantity = 2,
    Unit = "fdgh",
});

//Corporation database instances::
Database.Instance.InsertCorporation(new Corporation {
    ID = 1,
    CorporationName = "Fisketorvet",
    Country = "Denmark",
    CityName = "Copenhagen",
    Zipcode = "3600",
    RoadName = "Kongensvej",
    BuildingNumber = "A1",
    CurrencyCode = CurrencyCode.DKK
});

Database.Instance.InsertCorporation(new Corporation {
    ID = 2,
    CorporationName = "Jensens Fiskebiks",
    Country = "Denmark",
    CityName = "Copenhagen",
    Zipcode = "3600",
    RoadName = "Kongensvej",
    BuildingNumber = "A1",
    CurrencyCode = CurrencyCode.DKK
});

Database.Instance.InsertCorporation(new Corporation {
    ID = 3,
    CorporationName = "Skabsrokken",
    Country = "Denmark",
    CityName = "Copenhagen",
    Zipcode = "3600",
    RoadName = "Kongensvej",
    BuildingNumber = "A1",
    CurrencyCode = CurrencyCode.DKK
});
//Corporation Database instance ending::

SalesOrder mySaleOrder = new SalesOrder
{
    OrderID = 1,
    FirstName = "Jim",
    LastName = "Damgaard",
    ZipCode = "9640",
    Road = "Statinonsvej",
    PhoneNumber = "21830475",
    TimeOfCreation = DateTime.Now,
    TimeOfAcceptance = DateTime.Now,
    status = "Confirmed",
    CustomerID = 1,
};
mySaleOrder.AddSalesOrderLine(Database.Instance.GetProductFromID(1), 2);
Database.Instance.InsertSaleOrder(mySaleOrder);

mySaleOrder = new SalesOrder
{
    OrderID = 2,
    TimeOfCreation = DateTime.Now,
    TimeOfAcceptance = DateTime.Now,
    status = "Packed",
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

Screen.Display(new Mainmenu());