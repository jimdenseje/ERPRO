using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.CustomerNS;
namespace ERPRO.DatabaseNS
{
    internal partial class Database
    {
        public static List<Person> PersonList { get; } = new List<Person>();

        public Person GetPerson(int id) {
            Person person = new Person();
            if(id == 0){
                person.ID = 0;
                person.AddresseID = 0;
                person.FirstName = null;
                person.LastName = null;
                person.PhoneNumber = null;
                person.Email = null;
            } else {
            using (var connection = getConnection()){
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Person WHERE ID=" + id;
                var reader = command.ExecuteReader();
                reader.Read();

                person.ID = reader.GetInt32(0);
                person.FirstName = reader.GetString(1);
                person.LastName = reader.GetString(2);
                person.PhoneNumber = reader.GetString(3);
                person.Email = reader.GetString(4);
                person.AddresseID = reader.GetInt32(5);
                }
            };
            return person;
        }

        

        public List<Person> GetPerson() {
            List<Person> Persons = new List<Person>();
            foreach (var crp in PersonList) {
                Persons.Add(crp);
            }
            return Persons;
        }

        public Person InsertPerson(Person Person) {
            PersonList.Add(Person);
            return Person;
        }

        public void UpdatePerson(Person Person, int id) {
            for (int i = 0; i < PersonList.Count; i++) {
                if (PersonList[i].ID == id) {
                    PersonList[i] = Person;
                    break;
                }
            }
        }

        public void DeletePerson(Person Person, int id) {
            for (int i = 0; i < PersonList.Count; i++) {
                if (PersonList[i].ID == id) {
                    PersonList.RemoveAt(i);
                    break;
                }
            }
        }
    }
}