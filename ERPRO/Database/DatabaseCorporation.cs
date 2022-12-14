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

        public void InsertCorporation(Corporation corporation) {
            list.Add(corporation);
        }

        public Corporation GetCorporation(int id) {
            Corporation corporation = new Corporation();
            using (var connection = getConnection())
            {
                var command = connection.CreateCommand(); 
                command.CommandText = "SELECT * FROM corporation WHERE ID=" + id;
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
                var command = connection.CreateCommand();
                if (corporation.ID == null || corporation.ID == 0){
                    //Setting the address
                    command.CommandText = 
                    @$"
                    INSERT INTO Addresse (Country, City, ZipCode, BuildingNumber, Road, LocationName)
                    Values ('{corporation.Country}', '{corporation.CityName}', '{corporation.Zipcode}', '{corporation.BuildingNumber}', '{corporation.RoadName}', '{corporation.LocationName}')
                    ";
                    command.ExecuteNonQuery();

                    //Getting the ID from initialy created addresse
                    var getAddressID = connection.CreateCommand();
                    getAddressID.CommandText = $"SELECT ID FROM Addresse WHERE BuildingNumber = '{corporation.BuildingNumber}' AND ZipCode = '{corporation.Zipcode}' AND Road = '{corporation.RoadName}'";
                    var addressIDReader = getAddressID.ExecuteReader();
                    addressIDReader.Read();
                    corporation.AddresseID = addressIDReader.GetInt32(0);
                    addressIDReader.Close();

                    //Setting the corporation with the address ID from the newly created address
                    command.CommandText = 
                    @$"
                    INSERT INTO Corporation (CorporationName, Currency, AddresseID)
                    VALUES ('{corporation.CorporationName}', '{corporation.CurrencyCode}', '{corporation.AddresseID}');
                    ";
                } else {
                    command.CommandText =
                    @$"UPDATE Corporation
                    SET CorporationName = '{corporation.CorporationName}', Currency = '{corporation.CurrencyCode.ToString()}'
                    WHERE ID = {corporation.ID};
                    UPDATE Addresse
                    SET Country = '{corporation.Country}', City = '{corporation.CityName}', ZipCode = '{corporation.Zipcode}', BuildingNumber = '{corporation.BuildingNumber}', Road = '{corporation.RoadName}', LocationName = '{corporation.LocationName}'
                    WHERE ID = {corporation.AddresseID};
                    ";
                }
                command.ExecuteNonQuery();
            }
        }

        public bool DeleteCorporation(Corporation corporation) {
            using (var connection = getConnection()) {
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM corporation WHERE ID=" + corporation.ID;
                int deleted = command.ExecuteNonQuery();
                return deleted > 0;
            }
        }
    }
}
