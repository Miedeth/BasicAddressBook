using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddressBook.Models
{
    public enum PhoneNumberTypes
    {
        Home = 1,
        Cell = 2,
        Work = 3
    }

    public class PhoneNumber
    {
        public int PhoneNumberId { get; set; }
        public string Number { get; set; }
        public PhoneNumberTypes Type { get; set; }
    }
}