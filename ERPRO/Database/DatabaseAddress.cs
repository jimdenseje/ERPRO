using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.CustomerNS;
using ERPRO.AddressNS;

namespace ERPRO.DatabaseNS
{
    internal partial class Database
    {
        public static List<Address> AddressList = new List<Address>();

        public void InsertAddress(Address Address) {
            AddressList.Add(Address);
        }

        public Address GetAddress(int id) {
            Address addresse = new Address();
            using (var connection = getConnection())
            {
                var command = connection.CreateCommand(); 
                command.CommandText = "SELECT * FROM Addresse WHERE ID=" + id;
                var reader = command.ExecuteReader();
                reader.Read();
                addresse.ID = reader.GetInt32(0);
                addresse.Country = reader.GetString(1);
                addresse.City = reader.GetString(2);
                addresse.ZipCode = reader.GetString(3);
                addresse.BuildingNumber = reader.GetString(4);
                addresse.Road = reader.GetString(5);
                addresse.LocationName = reader.GetString(6);
            };
            return addresse;
        }

        public List<Address> GetAddress() {
            List<Address> addresses = new List<Address>();
            using (var connection = getConnection()){
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Addresse";
                var reader = command.ExecuteReader();
                while(reader.Read()){
                    Address addresse = new Address();
                    addresse.ID = reader.GetInt32(0);
                    addresse.Country = reader.GetString(1);
                    addresse.City = reader.GetString(2);
                    addresse.ZipCode = reader.GetString(3);
                    addresse.BuildingNumber = reader.GetString(4);
                    addresse.Road = reader.GetString(5);
                    addresse.LocationName = reader.GetString(6);
                    addresses.Add(addresse);
                }
                reader.Close();
            }
            return addresses;
        }

        public void UpdateAddress(Address Address) {
            using (var connection = getConnection()){
                var command = connection.CreateCommand();
                command.CommandText =
                @$"UPDATE Addresse
                SET Country = '{Address.Country}', City = '{Address.City}', ZipCode = '{Address.ZipCode}', BuildingNumber = '{Address.BuildingNumber}', Road = '{Address.Road}', LocationName = '{Address.LocationName}'
                WHERE ID = {Address.ID};
                ";
                command.ExecuteNonQuery();
            }
        }

        public bool DeleteAddress (Address Address) {
            using (var connection = getConnection()){
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Address WHERE ID=" + Address.ID;
                int deleted = command.ExecuteNonQuery();
                return deleted > 0;
            }
        }
    }
}