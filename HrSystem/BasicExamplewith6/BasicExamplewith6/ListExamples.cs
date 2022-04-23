using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicExamplewith6
{
    // public static void main();
    public delegate bool ConditionsList<T>(T s);
    public class ListExamples
    {

        
        public static List<string> GetNames()
        {
            var names = new List<string>(13)
           {
                "Ketaki",
                "Mathan",
                "Abhay",
                "abhijeet",
                "Nikita",
                "Manish",
                "AMit",
                "Suraj",
                "Pranit",
                "Mayank"
           };

            return names;
        }
        public static void Example1()
        {

           var names=GetNames();



          var outPut=  names.FirstOrDefault();

            for(int i = 0; i < names.Count; i=i+1)
            {
                Console.WriteLine(names[i]);
            }

            foreach(string name in names)
            {
                Console.WriteLine(name);
            }
        }

        public static void Example2()
        {
            var names = GetNames();

           

        }

        public static void Example3()
        {
            var names = GetNames();

           // var results = Condition(names, (x) => x.StartsWith("M"));

            var results =  names.Condition((x) => x.StartsWith("M"));

             
        }


        public static void Example4()
        {
            
        }


        
        public static List<T> Condition<T>(List<T> arr, ConditionsList<T> conditions)
        {
            var lst = new List<T>();             
            foreach (var item in arr)
            {
                if (conditions(item))
                {
                     lst.Add(item);
                }
            }
            return lst;
        }


         

        public static void Print(string[] arr)
        {

            foreach (var item in arr)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    Console.WriteLine(item);
                }
            }            
        }

    }
}
