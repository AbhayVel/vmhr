using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicExamplewith6
{
    internal class StringExample
    {

        public static void Example1()
        {

            
            
            string name = "Mr Manthan Mulajkar";// "Mrs Ketaki";
            string enteredName = "KeTaKi";
           var output= name.Split(" ");
            var sub = name.Substring(3,7);
            //if (name.ToUpper() == enteredName.ToUpper())
            // {
            //     Console.WriteLine("You are logged in");
            // } else
            // {
            //     Console.WriteLine("Please enter proper user Name");
            // }

          var index=  name.Contains("Mx");

            if(name.StartsWith("Mrs "))
            {
                Console.WriteLine("Girl");
            }
            if (name.StartsWith("Mr "))
            {
                Console.WriteLine("Boy");
            }



        }
    }
}
