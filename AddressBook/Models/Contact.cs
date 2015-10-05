using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddressBook.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public Address Address { get; set; }

        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public string WorkPhone { get; set; }

        public int? AddressId
        {
            get
            {
                if (Address == null)
                    return null;
                else
                    return Address.AddressId;
            }
        }
    }
}