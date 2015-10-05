using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddressBook.Models
{
    public enum AddressTypes
    {
        Home = 1,
        Work = 2
    }

    public class Address
    {
        public int AddressId { get; set; }
        public AddressTypes Type { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}