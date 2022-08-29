using TECHCOOL.UI;
using ERPRO.CorporationNS;
using ERPRO.DatabaseNS;
using ERPRO.MainNS;
using ERPRO.CustomerNS;

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

Database.Instance.InsertCustomer(new Customer
{
    CustomerID = 1,
    ID = 1,
    FirstName = "Jim",
    LastName = "Damgaard",
    PhoneNumber = "+4550533174",
    Email = "jimdenseje@gmail.com"
});

Database.Instance.InsertCustomer(new Customer
{
    CustomerID = 2,
    ID = 2,
    FirstName = "Jim",
    LastName = "Damgaard",
    PhoneNumber = "+4550533174",
    Email = "jimdenseje@gmail.com"
});

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
Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.WriteLine(intro);
Console.ForegroundColor = ConsoleColor.White;
Console.ReadKey();

Screen.Display(new Mainmenu());