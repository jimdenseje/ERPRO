using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECHCOOL.UI;
using ERPRO.DatabaseNS;
using ERPRO.CorporationNS;

namespace ERPRO.SalesNS
{
    public class SalesOrderLinesEdit : Screen
    {
        public override string Title { get; set; } = "Edit Sales module";
        private SalesOrderLine salesOrderLine { get; set; }
        public SalesOrderLinesEdit(SalesOrderLine salesOrderLine)
        {
            this.salesOrderLine = salesOrderLine;
        }
        protected override void Draw()
        {
            Clear(this);
            Form<SalesOrderLine> edit = new Form<SalesOrderLine>();
            edit.TextBox("SaleQty", "SaleQty");
            edit.Edit(salesOrderLine);
            Quit();
            Clear(this);
        }
    }
}