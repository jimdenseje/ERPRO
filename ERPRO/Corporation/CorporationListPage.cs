using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.DatabaseNS;
using TECHCOOL.UI;
using ERPRO.Functions.Print;

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
                keyheader.KeyHeader("corporation");
                listPage = new ListPage<Corporation>();
                listPage.AddKey(ConsoleKey.F1, addCorporation);
                listPage.AddKey(ConsoleKey.F2, editCorporation);
                listPage.AddKey(ConsoleKey.F5, deleteCorporation);
                listPage.AddColumn("Companyname", nameof(Corporation.CorporationName), 30);
                listPage.AddColumn("Country", nameof(Corporation.Country), 15);
                listPage.AddColumn("Currency", nameof(Corporation.CurrencyCode), 15);
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
                listPage.Add(newCorporation);
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