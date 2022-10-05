using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using ERPRO.CustomerNS;

namespace ERPRO.DatabaseNS
{
    internal partial class Database
    {
        public static List<Customer> CustomerList = new List<Customer>();

        public void InsertCustomer(Customer Customer) {
            CustomerList.Add(Customer);
        }

        public Customer GetCustomer(int id) {
            Customer customer = new Customer();
            if(id == 0){
                customer.ID = 0;
                customer.CustomerNumber = 0;
                customer.LastPurchase = DateTime.Now;
            } else {
            using (var connection = getConnection()){
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Customer WHERE ID=" + id;
                var reader = command.ExecuteReader();
                reader.Read();
                customer.ID = reader.GetInt32(0);
                customer.CustomerNumber = reader.GetInt32(1);
                customer.LastPurchase = reader.GetDateTime(2);
                }
            };
            return customer;
        }

        public List<Customer> GetCustomer() {
            List<Customer> customers = new List<Customer>();

            using (var connection = getConnection()){
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Customer";
                var reader = command.ExecuteReader();
                while(reader.Read()){
                    Customer customer = new Customer();
                    customer.ID = reader.GetInt32(0);
                    customer.CustomerNumber = reader.GetInt32(1);
                    try{customer.LastPurchase = reader.GetDateTime(2);}
                    catch(SqlNullValueException e) {
                        customers.Add(customer);
                    };  
                    DateTime nullvalue = new DateTime(0001, 1, 01, 0, 0, 0);
                    if(customer.LastPurchase != nullvalue) {
                        customers.Add(customer);
                    }          
                }
                reader.Close();

                foreach (var customer in customers)
                {
                    var personCommand = connection.CreateCommand();
                    personCommand.CommandText = "SELECT * FROM Person WHERE ID =" + customer.ID;
                    var personReader = personCommand.ExecuteReader();
                    personReader.Read();
                    customer.FirstName = personReader.GetString(1);
                    customer.LastName = personReader.GetString(2);
                    customer.PhoneNumber = personReader.GetString(3);
                    customer.Email = personReader.GetString(4);
                    customer.AddresseID = personReader.GetInt32(5);
                    personReader.Close();
                }

                foreach (var customer in customers)
                {
                    var addressCommand = connection.CreateCommand();
                    addressCommand.CommandText = "SELECT * FROM Addresse WHERE ID =" + customer.AddresseID;
                    var addressReader = addressCommand.ExecuteReader();
                    addressReader.Read();
                    customer.Country = addressReader.GetString(1);
                    customer.City = addressReader.GetString(2);
                    customer.ZipCode = addressReader.GetString(3);
                    customer.BuildingNumber = addressReader.GetString(4);
                    customer.Road = addressReader.GetString(5);
                    customer.LocationName = addressReader.GetString(6);
                    addressReader.Close();
                }
            }
            return customers;
        }

        public void UpdateCustomer(Customer customer) {
            using (var connection = getConnection()){
                var command = connection.CreateCommand();
                if (customer.ID == null || customer.ID == 0){
                    //Setting the address
                    command.CommandText = 
                    @$"
                    INSERT INTO Addresse (Country, City, ZipCode, BuildingNumber, Road, LocationName)
                    Values ('{customer.Country}', '{customer.City}', '{customer.ZipCode}', '{customer.BuildingNumber}', '{customer.Road}', '{customer.LocationName}')
                    ";
                    command.ExecuteNonQuery();

                    //Getting the ID from initialy created addresse
                    var getAddressID = connection.CreateCommand();
                    getAddressID.CommandText = $"SELECT ID FROM Addresse WHERE BuildingNumber = '{customer.BuildingNumber}' AND ZipCode = '{customer.ZipCode}' AND Road = '{customer.Road}'";
                    var addressIDReader = getAddressID.ExecuteReader();
                    addressIDReader.Read();
                    customer.AddresseID = addressIDReader.GetInt32(0);
                    addressIDReader.Close();

                    //Setting the corporation with the address ID from the newly created address
                    command.CommandText = 
                    @$"
                    INSERT INTO Person (FirstName, LastName, PhoneNumber, Email, AddresseID)
                    VALUES ('{customer.FirstName}', '{customer.LastName}', '{customer.PhoneNumber}', '{customer.Email}', '{customer.AddresseID}');
                    ";
                    command.ExecuteNonQuery();

                    //Getting the ID from initialy created person
                    var personID = connection.CreateCommand();
                    personID.CommandText = $"SELECT ID FROM Person WHERE Email = '{customer.Email}'";
                    var personIDreader = personID.ExecuteReader();
                    personIDreader.Read();
                    customer.ID = personIDreader.GetInt32(0);
                    personIDreader.Close();

                    command.CommandText = 
                    @$"
                    INSERT INTO Customer (ID)
                    VALUES ('{customer.ID}')
                    ";
                    command.ExecuteNonQuery();

                    var customerNumber = connection.CreateCommand();
                    customerNumber.CommandText = $"SELECT CustomerNumber FROM Customer WHERE ID = '{customer.ID}'";
                    var customerNumberReader = customerNumber.ExecuteReader();
                    customerNumberReader.Read();
                    customer.CustomerNumber = customerNumberReader.GetInt32(0);
                    customerNumberReader.Close();
                } else {
                command.CommandText =
                @$"UPDATE Person
                SET FirstName = '{customer.FirstName}', LastName = '{customer.LastName}', PhoneNumber = '{customer.PhoneNumber}', Email = '{customer.Email}'
                WHERE ID = {customer.ID}
                UPDATE Addresse
                SET Country = '{customer.Country}', City = '{customer.City}', ZipCode = '{customer.ZipCode}', BuildingNumber = '{customer.BuildingNumber}', Road = '{customer.Road}'
                WHERE ID = {customer.AddresseID}
                ";
                command.ExecuteNonQuery();
                }
            }
        }
        

        public bool DeleteCustomer(Customer customer) {
            using (var connection = getConnection()) {
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM customer WHERE ID=" + customer.ID;
                int deleted = command.ExecuteNonQuery();
                return deleted > 0;
            }
        }
    }
}