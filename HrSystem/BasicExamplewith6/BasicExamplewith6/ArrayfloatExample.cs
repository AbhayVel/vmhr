using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicExamplewith6
{

     
    internal class ArrayFloatExample
    {

        public static float[] GetFloat()
        {
            float[] nums = new float[]
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
                13
            };

            return nums;
        }

        public static void Example1()
        {

            float[] nums= GetFloat();

            // float[] results= LessThen(nums, 6);
            //  Print(results);

            // results = GreaterThen(nums, 6);

            // results = Condition(nums, (x) => x > 6);
            //float[] results = MyLinq.Condition(nums, (x) => x > 6);
          //  Print(results);

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
            return arrResult;
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

        public static void Print(float[] arr)
        {
            foreach (var item in arr)
            {                 
              Console.WriteLine(item);                
            }
        }



    }
}
