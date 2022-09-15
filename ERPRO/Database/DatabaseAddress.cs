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
        public static List<Address> AddressList { get; } = new List<Address>();

        public Address GetAddress(int id) {
            Address result = null;
            foreach (var Address in AddressList)
            {
                if (id == Address.ID) {
                    result = Address;
                    break;
                }
            }
            return result;
        }

        public List<Address> GetAddress() {
            List<Address> Addresses = new List<Address>();
            foreach (var addr in Addresses) {
                Addresses.Add(addr);
            }
            return Addresses;
        }

        public Address InsertAddress(Address Address) {
            AddressList.Add(Address);
            return Address;
        }

        public void UpdateAddress(Address Address, int id) {
            for (int i = 0; i < AddressList.Count; i++) {
                if (AddressList[i].ID == id) {
                    AddressList[i] = Address;
                    break;
                }
            }
        }

        public void DeleteAddress (Address Address, int id) {
            for (int i = 0; i < AddressList.Count; i++) {
                if (AddressList[i].ID == id) {
                    AddressList.RemoveAt(i);
                    break;
                }
            }
        }
    }
}