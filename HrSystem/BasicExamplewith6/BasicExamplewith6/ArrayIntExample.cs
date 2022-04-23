using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicExamplewith6
{

    public delegate bool ConditionsInt(int s);
    internal class ArrayIntExample
    {

        public static int[] GetInt()
        {
            int[] nums = new int[]
            {
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10,
                11,
                12,
                13,
                1,
                1,
                12,

                1222,
                111,
                3,
                4

            };

            return nums;
        }

        public static void Example1()
        {

            int[] nums= GetInt();

           int[] results= LessThen(nums, 6);
          //  Print(results);

         results = GreaterThen(nums, 6);

            // results = Condition(nums, (x) => x > 6);
          //  results = MyLinq.Condition( MyLinq.Condition(nums, (x) => x > 6), (x)=>x< 11);
             nums.Condition((x) => x <6).Condition((x)=>x >0).Print();

            

        }


        public static int[] Condition(int[] arr , ConditionsInt conditionsInt)
        {
            int i = 0;
            int[] arrResult = new int[arr.Length];
            foreach (var item in arr)
            {
                if (conditionsInt(item))
                {
                    arrResult[i] = item;
                    i++;
                }
            }

            int[] arrNew = new int[i];

            for (int j = 0; j < i; j++)
            {
                arrNew[j] = arrResult[j];
            }
            return arrNew;
        }

        public static int[] LessThen(int[] nums, int value)
        {
            int i = 0;
            int[] result = new int[nums.Length];
            foreach (var item in nums)
            {
                if(item < value)
                {
                    result[i] = item;
                    i= i + 1;
                }
            }
            return result;    
        }


        public static int[] GreaterThen(int[] nums, int value)
        {
            int i = 0;
            int[] result = new int[nums.Length];
            foreach (var item in nums)
            {
                if (item > value)
                {
                    result[i] = item;
                    i = i + 1;
                }
            }
            return result;
        }

        public static void Print(int[] arr)
        {
            foreach (var item in arr)
            {                 
              Console.WriteLine(item);                
            }
        }



    }
}
