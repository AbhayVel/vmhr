using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicExamplewith6
{
    internal class NumberExamples
    {
        public static void Example()
        {
            //integer 
            sbyte sb;  //byte 
            short sh; //2 byte 
            int i;    //4byte 
            long l;   // 8byte 
            //-----------------
            byte b;   //1
            ushort us; //2 
            uint ui; //4
            ulong ul; //8 



            Console.WriteLine(SByte.MaxValue);
            Console.WriteLine(SByte.MinValue);

            Console.WriteLine(Byte.MaxValue);
            Console.WriteLine(Byte.MinValue);
            Console.WriteLine("Short values ");
            Console.WriteLine(short.MaxValue);
            Console.WriteLine(short.MinValue);

            Console.WriteLine("UShort values ");
            Console.WriteLine(ushort.MaxValue);
            Console.WriteLine(ushort.MinValue);

            SByte.TryParse("-2", out sb);

            //FLoating point 

            float f = 12.5f;
            double d = 12.8;

            decimal c = 34.9M;


        }
    }
}
