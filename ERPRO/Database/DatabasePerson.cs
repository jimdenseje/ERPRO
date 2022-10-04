using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPRO.CustomerNS;
using ERPRO.PersonNS;

namespace ERPRO.DatabaseNS
{
    internal partial class Database
    {
        public static List<Person> PersonList { get; } = new List<Person>();

        public Person GetPerson(int id) {
            Person result = null;
            foreach (var Person in PersonList)
            {
                if (id == Person.ID) {
                    result = Person;
                    break;
                }
            }
            return result;
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