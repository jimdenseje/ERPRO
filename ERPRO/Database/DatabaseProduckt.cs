using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.CorporationNS;
using ERPRO.ProducktsNS;

namespace ERPRO.DatabaseNS
{
    internal partial class Database
    {
        public static List<Produckt> ProducktList { get; } = new List<Produckt>();

        public Produckt GetProducktFromID(int id) {
            Produckt result = null;
            foreach (var produckts in ProducktList)
            {
                if (id == produckts.ItemID)
                {
                    result = produckts;
                    break;
                }
            }
            return result;
        }

        public List<Produckt> GetAllProduckts() {
            List<Produckt> produckts = new List<Produckt>();
            foreach (var pro in ProducktList) {
                produckts.Add(pro);
            }
            return ProducktList;
        }

        public Produckt InsertProduckt(Produckt produckts) {
            ProducktList.Add(produckts);
            return produckts;
        }

        public void UpdateProduckt(Produckt produckts, int id) {
            for (int i = 0; i < ProducktList.Count; i++) {
                if (ProducktList[i].ItemID == id) {
                    ProducktList[i] = produckts;
                    break;
                }
            }
        }

        public void DeleteProduckt(Produckt produckts, int id) {
            for (int i = 0; i < ProducktList.Count; i++) {
                if (ProducktList[i].ItemID == id) {
                    ProducktList.RemoveAt(i);
                    break;
                }
            }
        }

    }
}