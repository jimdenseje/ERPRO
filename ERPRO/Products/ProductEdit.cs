// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using TECHCOOL.UI;
// using ERPRO.DatabaseNS;
// using ERPRO.ProductNS;

// namespace ERPRO.CorporationNS
// {
//     public class ProductEdit : Screen
//     {
//         public override string Title { get; set; } = "Edit Product";
//         private Product product { get; set; }
//         public ProductEdit(Product product) {
//             this.corporation = corporation;
//         }
//         protected override void Draw()
//         {
//             Clear(this);
//             Form<Corporation> edit = new Form<Corporation>();
//             edit.TextBox("Corporation name", nameof(corporation.CorporationName));
//             edit.TextBox("Country", "Country");
//             edit.TextBox("City", "CityName");
//             edit.TextBox("Zip code", "Zipcode");
//             edit.TextBox("Road", "RoadName");
//             edit.TextBox("Building", "BuildingNumber");
//             edit.SelectBox("Currency code", "CurrencyCode");
//             edit.AddOption("Currency code", "None", CurrencyCode.None);
//             edit.AddOption("Currency code", "DKK", CurrencyCode.DKK);
//             edit.AddOption("Currency code", "USD", CurrencyCode.USD);
//             edit.AddOption("Currency code", "EUR", CurrencyCode.EUR);
//             edit.Edit(corporation);
//             Quit();
//             Clear(this);
//         }
//     }
// }