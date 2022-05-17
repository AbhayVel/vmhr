using System;
using System.Collections.Generic;
using System.Text;

namespace Examples
{
    internal class Person : IName
    {
        public Address Address { get; set; } 

        public Person(Address _address)
        {
            Address = _address;
        }

        public string Name { get; set; }

        public void SetAddress(Address address)
        {
            this.Address = address;
        }
    }
}
