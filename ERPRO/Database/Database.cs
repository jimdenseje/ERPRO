using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ERPRO.CorporationNS;

namespace ERPRO.DatabaseNS
{
    internal partial class Database
    {
        public static Database Instance { get; private set; }
        static Database() {
            Instance = new Database();
        }

        private SqlConnection getConnection() {
            SqlConnectionStringBuilder sb = new();
            sb.DataSource = "docker.data.techcollege.dk";
            sb.InitialCatalog = "H1PD081122_Gruppe4";
            sb.UserID = "H1PD081122_Gruppe4";
            sb.Password = "H1PD081122_Gruppe4";

            string connectionString = sb.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        private void Install() {
            string[] sql = new string [] {
                @"CREATE TABLE corporation (
                            ID INT IDENTITY(1,1)
                            ....
                            PRIMARY KEY(ID)
                            )",
                            @"CREATE TABLE customer (.....)",
                            @"CREATE TABLE products (.....)",
            };

            using (var conn = getConnection()) {
                foreach (string sqlCmd in sql) {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = sqlCmd;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool CheckConnection() {
            SqlConnection connection = null;
            try {
                connection = getConnection();
                return true;
            } 
            catch (SqlException error) {
                Console.Clear();
                Console.Write(error.Message);
                return false;
            }
            finally {
                connection.Dispose();
            }
        }

        //Query eksempel:: SELECT Top ' * FROM Company
    }
}