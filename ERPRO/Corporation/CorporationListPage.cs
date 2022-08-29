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
        public bool refresh;
        protected override void Draw()
        {   
            do {
                Clear(this);
                listPage = new ListPage<Corporation>();
                listPage.AddKey(ConsoleKey.F1, addCorporation);
                listPage.AddKey(ConsoleKey.F2, editCorporation);
                listPage.AddKey(ConsoleKey.F5, deleteCorporation);
                listPage.AddColumn("Companyname", "CorporationName", 30);
                listPage.AddColumn("Address", "RoadName", 15);
                var corporations = Database.Instance.GetCorporation();
                listPage.Add(corporations);
                var corporation = listPage.Select();
                if (corporation != null) {
                    var viewCorporationScreen = new CorporationView(corporation);
                    Screen.Display(viewCorporationScreen);
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
            if(newCorporation.CityName != null) {
                Database.Instance.InsertCorporation(newCorporation);
            }
        }

        void editCorporation(Corporation corporation) {
            CorporationEdit editor = new CorporationEdit(corporation);
            Display(editor);
            Database.Instance.UpdateCorporation(corporation, corporation.ID);
        }

         void deleteCorporation(Corporation corporation) {
            Database.Instance.DeleteCorporation(corporation, corporation.ID);
            listPage.Remove(corporation);
            Clear(this);
        }
    }
}