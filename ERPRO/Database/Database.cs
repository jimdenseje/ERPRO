using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.CorporationNS;

namespace ERPRO.DatabaseNS
{
    internal partial class Database
    {
        public static Database Instance { get; } = new Database();

        public static List<Corporation> CorporationList { get; } = new List<Corporation>();

        public Corporation GetCorporation(int id) {
            Corporation result = null;
            foreach (var corporation in CorporationList)
            {
                if (id == corporation.ID) {
                    result = corporation;
                    break;
                }
            }
            return result;
        }

        public List<Corporation> GetCorporation() {
            List<Corporation> corporations = new List<Corporation>();
            foreach (var crp in CorporationList) {
                corporations.Add(crp);
            }
            return corporations;
        }

        public Corporation InsertCorporation(Corporation corporation) {
            CorporationList.Add(corporation);
            return corporation;
        }

        public void UpdateCorporation(Corporation corporation, int id) {
            for (int i = 0; i < CorporationList.Count; i++) {
                if (CorporationList[i].ID == id) {
                    CorporationList[i] = corporation;
                    break;
                }
            }
        }

        public void DeleteCorporation(Corporation corporation, int id) {
            for (int i = 0; i < CorporationList.Count; i++) {
                if (CorporationList[i].ID == id) {
                    CorporationList.RemoveAt(i);
                    break;
                }
            }
        }

    }
}