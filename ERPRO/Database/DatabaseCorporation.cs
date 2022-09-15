using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.CorporationNS;
using System.Data.SqlClient;

namespace ERPRO.DatabaseNS
{
    internal partial class Database
    {
        //public static Database Instance { get; } = new Database();

        public static List<Corporation> CorporationList { get; } = new List<Corporation>();
        List<Corporation> list = new List<Corporation>();
        static int nextId = 0;

        public void InsertCorporation(Corporation corp) {
            list.Add(corp);
            corp.ID = nextId++;
        }

        public Corporation FindCompany(int id) {
            Corporation corporation = new Corporation();
            using (var connection = getConnection())
            {
                var command = connection.CreateCommand(); 
                command.CommandText = "SELECT CorporationName FROM company WHERE ID=" + id;
                var reader = command.ExecuteReader();
                reader.Read();
                corporation.ID = reader.GetInt32(0);
                corporation.CorporationName  = reader.GetString(1);
            };
            return corporation;
        }

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


        public void UpdateCorporation(Corporation corporation, int id) {
            for (int i = 0; i < CorporationList.Count; i++) {
                if (CorporationList[i].ID == id) {
                    CorporationList[i] = corporation;
                    break;
                }
            }
        }

        public bool DeleteCorporation(Corporation corp) {
            using (var connection = getConnection()) {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM corporation WHERE ID=" + corp.ID;
                int deleted = command.ExecuteNonQuery();
                return deleted > 0;
            }
        }
    }
}