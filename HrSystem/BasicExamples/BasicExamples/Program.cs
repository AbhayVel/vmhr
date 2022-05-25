using System;
using System.Linq;

namespace BasicExamples
{
    public class StartUp
    {
        public void Main()
        {

        }

        public void Call()
        {

        }

        public void GetData()
        {

        }
    }

    internal class Program
    {

        public static void UseStartUp<T>() where T : new()
        {
            var startUpType=new T();

            var methods = startUpType.GetType().GetMethods();
          var  main= methods.Where(x => x.Name == "Main").FirstOrDefault();
            if(main == null)
            {
                throw new Exception("Configure method is not part of Startup class.");
            } else
            {
                main.Invoke(startUpType, null);
            }
        }
        static void Main(string[] args)
        {
            try
            {
                UseStartUp<StartUp>();
            }
            catch (Exception ex)
            {

            }
           
            Console.WriteLine("Hello World!");
        }
    }
}
