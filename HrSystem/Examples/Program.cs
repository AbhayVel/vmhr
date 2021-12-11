using System;
using System.Collections.Generic;
using System.Linq;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> lst = new List<int> { 23, 3, 4, 5, 6, 7, 8, 2, 12, 45, 62, 24 };

            List<int> lst2 = lst.Skip(3).Take(2).ToList();
            Console.WriteLine("Hello World!");
        }
    }
}
