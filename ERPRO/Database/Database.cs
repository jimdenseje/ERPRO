using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.Corporation;

namespace ERPRO.Database
{
    internal partial class Database
    {
        public static Database Instance { get; } = new Database();

        public static List<Corporation.Corporation> CorporationList { get; } = new List<Corporation.Corporation>();

        public Corporation.Corporation GetCorporation(int id) {
            Corporation.Corporation result = null;
            foreach (var corporation in CorporationList)
            {
                if (id == corporation.ID) {
                    result = corporation;
                    break;
                }
            }
            return result;
        }

        public List<Corporation.Corporation> GetCorporation() {
            List<Corporation.Corporation> corporations = new List<Corporation.Corporation>();
            foreach (var crp in CorporationList) {
                corporations.Add(crp);
            }
            return corporations;
        }

        public Corporation.Corporation InsertCorporation(Corporation.Corporation corporation) {
            CorporationList.Add(corporation);
            return corporation;
        }

        public void UpdateCorporation(Corporation.Corporation corporation, int id) {
            for (int i = 0; i < CorporationList.Count; i++) {
                if (CorporationList[i].ID == id) {
                    CorporationList[i] = corporation;
                    break;
                }
            }
        }

        public void DeleteCorporation(Corporation.Corporation corporation, int id) {
            for (int i = 0; i < CorporationList.Count; i++) {
                if (CorporationList[i].ID == id) {
                    CorporationList.RemoveAt(i);
                    break;
                }
            }
        }
    }
}