using System;
using System.Collections.Generic;
using System.Text;

namespace Examples
{
    public interface IName
    {
        public string Name { get; set; }
    }
    public class Address : IName
    {

        public int Id { get; set; }

        public string Name { get; set; }
    }


    public class Location : IName
    {

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
