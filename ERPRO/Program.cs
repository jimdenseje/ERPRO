using TECHCOOL.UI;
using ERPRO.CorporationNS;
using ERPRO.DatabaseNS;
using ERPRO.MainNS;


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

Screen.Display(new Mainmenu());