using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace BasicExamples
{
    public class FeedTypeModel
    {
        public string columnName { get; set; }
        public string orderBy { get; set; }
       
    }
        public class Dummy
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
    public class StartUp
    {
        public void Main()
        {

        }
            public void Main2()
        {
            Dummy d=new Dummy();

            d.UserName = "AJ";
            d.Password = "abc";

            FeedTypeModel feed=new FeedTypeModel();
            feed.columnName = "Id";
            feed.orderBy = "asc";

            RestClient client = new RestClient("https://localhost:44367/api/FeedType/Index");
            RestRequest request = new RestRequest(JsonConvert.SerializeObject(feed), Method.Post);
            request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFiaGlqaXQiLCJyb2xlIjoibWFuYWdlciIsIm5iZiI6MTY1NzAzMzIzMiwiZXhwIjoxNjU3MTE5NjMyLCJpYXQiOjE2NTcwMzMyMzJ9.qfT8GqdfQUS_RRGdm42LUFcO1MJkFXeD-Lg4Yi3kM_s");
            var response = client.Execute(request);

            //using (var client = new WebClient()) //WebClient  
            //{
            //    client.Headers.Add("Content-Type:application/json"); //Content-Type  
            //    client.Headers.Add("Accept:application/json");
            //    client.Headers.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFiaGlqaXQiLCJyb2xlIjoibWFuYWdlciIsIm5iZiI6MTY1NzAzMzIzMiwiZXhwIjoxNjU3MTE5NjMyLCJpYXQiOjE2NTcwMzMyMzJ9.qfT8GqdfQUS_RRGdm42LUFcO1MJkFXeD-Lg4Yi3kM_s");
            //    var result = client.UploadString("https://localhost:44367/api/FeedType/Index", JsonConvert.SerializeObject(feed)); //URI  
            //    Console.WriteLine(Environment.NewLine + result);
            //}
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

        static void Main3(string[] args)
        {
             //

        }
            static void Main2(string[] args)
        {


            Dictionary<string, Dictionary<string,string>> sessions = new Dictionary<string, Dictionary<string,string>>();
            int[] arr = { 1, 5, 9 };
            int i = 1;
            arr[i++]=arr[i]+10;
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
