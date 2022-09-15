using TECHCOOL.UI;
using ERPRO.CorporationNS;
using ERPRO.DatabaseNS;
using ERPRO.MainNS;
using ERPRO.CustomerNS;
using ERPRO.ProductNS;
using ERPRO.SalesNS;
using GrapeCity.Documents.Imaging;
using ERPRO.Functions.Print;
using System.Linq.Expressions;
using System.Security.Cryptography;

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

//Storage instance::
Database.Instance.InsertAddress(new Address {
    ID = 0,
    Country = "",
    City = "",
    ZipCode = "",
    BuildingNumber = "",
    Road = "",
    LocationName = "No Storage"
});
Database.Instance.InsertAddress(new Address {
    ID = 1,
    Country = "Danmark",
    City = "Aarhus",
    ZipCode = "6666",
    BuildingNumber = "34",
    Road = "Karolinevej",
    LocationName = "Aarhus Lager"
});
Database.Instance.InsertAddress(new Address {
    ID = 2,
    Country = "Danmark",
    City = "Odense",
    ZipCode = "4560",
    BuildingNumber = "A2",
    Road = "Sveltevej",
    LocationName = "Odense Lager"
});
Database.Instance.InsertAddress(new Address {
    ID = 3,
    Country = "Danmark",
    City = "Tønder",
    ZipCode = "2344",
    BuildingNumber = "3",
    Road = "Grænsevej",
    LocationName = "Tønder Lager"
});

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

int[,] car =
{
    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
    {0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
    {0,0,0,3,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
    {0,0,0,3,3,3,3,0,0,0,0,0,0,0,2,0,0,0,0,0},
    {0,0,0,3,3,3,3,0,0,1,1,1,1,1,1,1,1,1,0,0},
    {0,0,0,3,3,3,0,0,0,1,1,1,1,1,1,1,1,1,0,0},
    {0,0,3,3,0,3,3,0,0,0,0,2,0,0,0,2,0,0,0,0},
};

Console.Clear();
Console.CursorVisible = false;
Console.ForegroundColor = ConsoleColor.DarkCyan;
//Console.WriteLine(intro);
Console.ForegroundColor = ConsoleColor.White;

//Read frames from the GIF image
GcGifReader reader = new GcGifReader("intro.gif");
var framesz = reader.Frames;

var posision = Console.GetCursorPosition();
Console.CursorVisible = false;

using (var bmp = new GcBitmap())
{
    //Loading GIF frames as individual images
    for (var loop = 0; loop < 1; loop++)
    {
        for (var i = 0; i < framesz.Count; i++)
        {
            framesz[i].ToGcBitmap(bmp, i - 1);

            Console.SetCursorPosition(posision.Left, posision.Top);
            Console.CursorVisible = false;

            System.Threading.Thread.Sleep(10);
            //Console.Clear();

            for (var x = 0; x < bmp.PixelHeight; x++)
            {
                for (var y = 0; y < bmp.PixelWidth; y++)
                {
                    ConsoleColor temp = animation.ClosestConsoleColorFromUInt(bmp[y, x]);
                    Console.ForegroundColor = temp;
                    Console.BackgroundColor = temp;
                    Console.Write("*");

                }

                Console.WriteLine();
            }

            for (var x = 0; x < 7; x++)
            {

                //own drawing
                int startpos = 0;
                int endpos = 20;
                if (i * 2 > 55)
                {
                    Console.Write("".PadLeft(i * 2 - 9));
                    endpos = endpos - (i - 25);
                    if (endpos < 0) {
                        endpos = 0;
                    }
                }
                else if (9 - (i * 2) > 0)
                {
                    startpos = 9 - (i * 2);
                }
                else
                {
                    Console.Write("".PadLeft((i * 2) -9));
                    startpos = 0;
                }

                for (var y = startpos; y < endpos; y++)
                {
                    switch (car[x, y])
                    {
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write("**");
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Write("**");
                            break;
                        case 1:
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("**");
                            break;
                        default:
                            Console.Write("  ");
                            break;
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;

                }
                Console.WriteLine("");
            }
            //stop own drawing

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n           -- Made by GRP4 - Jim, Marcus & Tobias");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}


Console.ForegroundColor = ConsoleColor.White;
Console.BackgroundColor = ConsoleColor.Black;
System.Threading.Thread.Sleep(100);
//Console.ReadKey();
Console.SetCursorPosition(0, 0);
Console.Clear();
Console.CursorVisible = false; //fix for rezising

Screen.Display(new Mainmenu());