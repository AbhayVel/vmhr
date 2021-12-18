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

            bool isAdult = false;
            bool result = IsAdultAndCanMarry(19,"F", out isAdult);
            try
            {
                int i = Int32.Parse("89x");

            }
           catch(Exception ex)
            {

            }
            int j = 0;
           bool result2= Int32.TryParse("89", out j);


        }


        public static Tuple<bool,bool> IsAdultAndCanMarry(int age, string gender)
        {
            bool isAdult = false;
            bool isMarry = false;

            if (age > 18)
            {
                isAdult = true;
            }
            else
            {
                isAdult = false;
            }
            if (age > 18 && "F".Equals(gender))
            {

                isMarry =true;
            }
            if (age > 21 && "M".Equals(gender))
            {
                isMarry= true;
            }

            Tuple<bool,bool> result= new Tuple<bool,bool>(isAdult,isMarry);
            return result;

        }
            public static bool IsAdultAndCanMarry(int age, string gender, out bool isAdult)
        {
            if(age > 18)
            {
                isAdult = true;
            }else
            {
                isAdult = false;
            }
            if(age> 18 && "F".Equals(gender))
            {
                
                return true;
            }
            if (age > 21 && "M".Equals(gender))
            {
                return true;
            }

            return false;




            return false;
            
        }
    }
}
