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
        List<Corporation> list = new List<Corporation>();
        static int nextId = 0;

        public void InsertCorporation(Corporation corporation) {
            list.Add(corporation);
            corporation.ID = nextId++;
        }

        public Corporation GetCorporation(int id) {
            Corporation corporation = new Corporation();
            using (var connection = getConnection())
            {
                var command = connection.CreateCommand(); 
                command.CommandText = "SELECT CorporationName FROM corporation WHERE ID=" + id;
                var reader = command.ExecuteReader();
                reader.Read();
                corporation.ID = reader.GetInt32(0);
                corporation.CorporationName  = reader.GetString(1);
            };
            return corporation;
        }

        public List<Corporation> GetCorporation() {
            List<Corporation> corporations = new List<Corporation>();
            using (var connection = getConnection())
            {
                var command = connection.CreateCommand(); 
                command.CommandText = "SELECT * FROM corporation";
                var reader = command.ExecuteReader();

                while(reader.Read()){
                    Corporation corporation = new Corporation();
                    corporation.ID = reader.GetInt32(0);
                    corporation.CorporationName  = reader.GetString(1);
                    corporation.CurrencyCode = Enum.Parse<CurrencyCode>(reader.GetString(2));
                    corporation.AddresseID = reader.GetInt32(3);
                    corporations.Add(corporation);
                }
                reader.Close();

                foreach (var corp in corporations)
                {
                    var addressCommand = connection.CreateCommand();
                    addressCommand.CommandText = "SELECT * FROM Addresse WHERE ID =" + corp.AddresseID;
                    var addressReader = addressCommand.ExecuteReader();
                    addressReader.Read();
                    corp.Country = addressReader.GetString(1);
                    corp.CityName = addressReader.GetString(2);
                    corp.Zipcode = addressReader.GetString(3);
                    corp.BuildingNumber = addressReader.GetString(4);
                    corp.RoadName = addressReader.GetString(5);
                    addressReader.Close();
                }
            
            };

            return corporations;
        }

        public void UpdateCorporation(Corporation corporation) {
            using (var connection = getConnection()){
                string currencycode = corporation.CurrencyCode.ToString();
                var command = connection.CreateCommand();
                command.CommandText =
                @$"UPDATE Corporation
                SET CorporationName = '{corporation.CorporationName}', Currency = '{currencycode}'
                WHERE ID = {corporation.ID};
                UPDATE Addresse
                SET Country = '{corporation.Country}', City = '{corporation.CityName}', ZipCode = '{corporation.Zipcode}', BuildingNumber = '{corporation.BuildingNumber}', Road = '{corporation.RoadName}', LocationName = '{corporation.LocationName}'
                WHERE ID = {corporation.AddresseID};
                ";
                command.ExecuteNonQuery();
            }
        }

        public bool DeleteCorporation(Corporation corporation) {
            using (var connection = getConnection()) {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM corporation WHERE ID=" + corporation.ID;
                int deleted = command.ExecuteNonQuery();
                return deleted > 0;
            }
        }
    }
}