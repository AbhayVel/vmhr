using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicExamplewith6
{
   // public static void main();
    public delegate bool Conditions(string s);
    public class ArrayExamples
    {

        
        public static string[] GetNames()
        {
            var names = new string[]
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


            for(int i = 0; i < names.Length; i=i+1)
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

            string[] startWithA = new string[names.Length];
            string[] startWithM = new string[names.Length];
            int i = 0;
            foreach (var item in names)
            {
                if (item.ToUpper().StartsWith("A"))
                {
                    startWithA[i] = item;
                    i++;
                }
            }


            i = 0;
            foreach (var item in names)
            {
                if (item.ToUpper().StartsWith("M"))
                {
                    startWithM[i] = item;
                    i++;
                }
            }

            Console.WriteLine("Team Start with A");
            foreach (var item in startWithA)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine("Team Start with M");
            foreach (var item in startWithM)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    Console.WriteLine(item);
                }
            }

        }

        public static void Example3()
        {
            var names = GetNames();

            string[] startWithA = new string[names.Length];
            string[] startWithM = new string[names.Length];
            string[] startWithN = new string[names.Length];
            int i = 0;
            int j = 0;
            int k = 0;
            foreach (var item in names)
            {
                if (item.ToUpper().StartsWith("A"))
                {
                    startWithA[i] = item;
                    i++;
                } else if (item.ToUpper().StartsWith("M"))
                {
                    startWithM[j] = item;
                    j++;
                }
                else if (item.ToUpper().StartsWith("N"))
                {
                    startWithN[k] = item;
                    k++;
                }
            }           

            Console.WriteLine("Team Start with A");
            foreach (var item in startWithA)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine("Team Start with M");
            foreach (var item in startWithM)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine("Team Start with N");
            foreach (var item in startWithN)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    Console.WriteLine(item);
                }
            }

        }


        public static void Example4()
        {
            var names = GetNames();

            string[] startWithA = Condition(names, "A", "STARTSWITH");
            var startWithM = MyLinq.Condition(names,(x)=>x.StartsWith("M"));
            var startWithN =  names.Condition((x)=>x.StartsWith("N"));

            string[] endWithT = Condition(names, (x) => x.EndsWith("N"));

            string[] containsK = Condition(names, (c1)=>c1.StartsWith("A") && c1.EndsWith("y"));


            startWithM.Print();
            //Console.WriteLine("Team Start with A");
            //Print(startWithA);
            Console.WriteLine("Team Start with M");
            //Print(startWithM);
            //Console.WriteLine("Team Start with N");
            //Print(startWithN);
            //Console.WriteLine("Team ENd with T");
            //Print(endWithT);

            Console.WriteLine("Team Start with A and end with y");
            Print(containsK);
        }



        public static string[] Condition(string[] arr, Conditions conditions)
        {
            int i = 0;
            string[] arrResult = new string[arr.Length];
            foreach (var item in arr)
            {
                if (conditions(item))
                {
                    arrResult[i] = item;
                    i++;
                }
            }
            return arrResult;
        }


        public static string[] Condition(string[] arr, string value, string condition)
        {
            int i = 0;
            string[] arrResult = new string[arr.Length];
            foreach (var item in arr)
            {
                if ("STARTSWITH".Equals(condition.ToUpper()))
                {
                    if (item.ToUpper().StartsWith(value))
                    {
                        arrResult[i] = item;
                        i++;
                    }
                } else if ("ENDSWITH".Equals(condition.ToUpper()))
                {
                    if (item.ToUpper().EndsWith(value))
                    {
                        arrResult[i] = item;
                        i++;
                    }
                }
                else if ("CONTAINS".Equals(condition.ToUpper()))
                {
                    if (item.ToUpper().Contains(value))
                    {
                        arrResult[i] = item;
                        i++;
                    }
                }


            }
            return arrResult;
        }




        public static string[] GetStartWith(string[] arr,string value)
        {
            int i = 0;
            string[] arrResult=new string[arr.Length];
            foreach (var item in arr)
            {
                if (item.ToUpper().StartsWith(value))
                {
                    arrResult[i] = item;
                    i++;
                }
                 
            }
            return arrResult;
        }


        public static string[] GetEndWith(string[] arr, string value)
        {
            int i = 0;
            string[] arrResult = new string[arr.Length];
            foreach (var item in arr)
            {
                if (item.ToUpper().EndsWith(value))
                {
                    arrResult[i] = item;
                    i++;
                }

            }
            return arrResult;
        }

        public static string[] GetContains(string[] arr, string value)
        {
            int i = 0;
            string[] arrResult = new string[arr.Length];
            foreach (var item in arr)
            {
                if (item.ToUpper().Contains(value))
                {
                    arrResult[i] = item;
                    i++;
                }

            }
            return arrResult;
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
