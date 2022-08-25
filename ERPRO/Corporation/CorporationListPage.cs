using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.DatabaseNS;
using TECHCOOL.UI;

namespace ERPRO.CorporationNS
{
    public class CorporationListPage : Screen
    {
        ListPage<Corporation> listPage;
        public override string Title { get; set; } = "Corporations";
        protected override void Draw()
        {
            do {
                Clear(this);
                listPage = new ListPage<Corporation>();
                listPage.AddKey(ConsoleKey.F1, addCorporation);
                listPage.AddColumn("Companyname", "CorporationName", 30);
                listPage.AddColumn("Address", "RoadName", 15);
                var corporations = Database.Instance.GetCorporation();
                listPage.Add(corporations);
                var corporation = listPage.Select();
                if (corporation != null) {
                    var editCorporationScreen = new CorporationEdit(corporation);
                    Screen.Display(editCorporationScreen);
                } else {
                    Quit();
                    return;
                }
            } while (Show);
        }
        void addCorporation(Corporation _) {
            Corporation newCorporation = new Corporation();
            CorporationEdit editor = new CorporationEdit(newCorporation);
        
            Display(editor);
            Database.Instance.InsertCorporation(newCorporation);
        }
    }
}