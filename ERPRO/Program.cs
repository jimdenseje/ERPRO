using TECHCOOL.UI;
using ERPRO.CorporationNS;
using ERPRO.DatabaseNS;
using ERPRO.MainNS;
using ERPRO.CustomerNS;


Database.Instance.InsertCorporation(new Corporation {
    CorporationName = "Fisketorvet",
    RoadName = "Wrongroad",
    ID = 1
});

Database.Instance.InsertCorporation(new Corporation {
    CorporationName = "Trælsetove",
    RoadName = "Rightroad",
    ID = 2
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

Screen.Display(new Mainmenu());