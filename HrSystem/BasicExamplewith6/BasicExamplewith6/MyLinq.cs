using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicExamplewith6
{

    public delegate bool Condition<T>(T s);
    public static class MyLinq 
    {

        public static void Print<T>(this IEnumerable<T> arr)  
        {
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        //public static void Print<T>(this IEnumerable<T> arr) //Extention method
        //{
        //    foreach (var item in arr)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}

        public static T[] ToConvertArray<T>(this IEnumerable<T> arr) //Extention method
        {
            var lst = arr.ToConvertList();
           var arrResult=new T[lst.Count];
            int i=0;
            foreach (var item in arr)
            {
                arrResult[i++]=item;
            }

            return arrResult;
        }

        public static List<T> ToConvertList<T>(this IEnumerable<T> arr) //Extention method
        {
            var lst= new List<T>();
            foreach (var item in arr)
            {
                lst.Add(item);
            }

            return lst;
        }
        public static T[] Condition_oldWay<T>(this T[] arr, Condition<T> condition) //Extention method
        {
            int i = 0;
            T[] arrResult = new T[arr.Length];
            foreach (var item in arr)
            {
                if (condition(item))
                {
                    arrResult[i] = item;
                    i++;
                }
            }            
            T[] arrNew = new T[i];
            for (int j = 0; j < i; j++)
            {
                arrNew[j] = arrResult[j];
            }
            return arrNew;
           // return arrResult;
        }



        public static  T MyFirstOrDefault<T>(this IEnumerable<T> arr, Condition<T>? condition) //Extention method
        {
           
            foreach (var item in arr)
            {
                if (condition == null)
                {
                    return item;
                }
                else if (condition(item))
                {
                     return item;
                }
            }

            return default(T);
        }


            //Where
            public static IEnumerable<T> Condition<T>(this IEnumerable<T> arr, Condition<T> condition) //Extention method
        {
          
            foreach (var item in arr)
            {
                if (condition(item))
                {
                    yield return item;
                }
            }
            
            
        }




    }
}
