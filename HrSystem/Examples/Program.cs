using HRDB;
using HREntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Examples
{
    class Program
    {
        static Dictionary<string, string> TrValue = new Dictionary<string, string>()
        {
            {"sun","soleil" },
            { "shines","brille"}
        };
        public static string Translet(string english)
        {
            string french = "";
            string[] engArray=english.Split(' ');
            for (int i = 0; i < engArray.Length; i++)
            {
                french+=" " + TrValue[engArray[i]].ToString();
            }

            return french;
        }

      static void Main(string[] args)
      {
         var output=   Translet("sun shines");

            

             

           
         HrSystemDBContext hrdb = new HrSystemDBContext("Data Source=DESKTOP-C0FBNF9\\SQLEXPRESS;Initial Catalog=HRSystem;Integrated Security=True");

            //hrdb.FeedType.Add(new FeedType
            //{
            //    TypeText = "Video"
            //});

            //hrdb.FeedType.Add(new FeedType
            //{
            //    TypeText = "Image"
            //});

            //hrdb.FeedType.Add(new FeedType
            //{
            //    TypeText = "Audio"
            //});

            //hrdb.FeedType.Add(new FeedType
            //{
            //    TypeText = "Text"
            //});

           var feed= hrdb.FeedType.Where(x=>x.TypeText.Equals("Audio1")).FirstOrDefault();

            hrdb.FeedType.Remove(feed);


            hrdb.SaveChanges();
            var users = hrdb.FeedType.ToList();

            foreach (var item in users)
            {
                Console.WriteLine(item.TypeText);
            }

           // ArrayList l = new ArrayList();

           //List<string> lst= new List<string>();
             
           // l.Add(2); ///<- primitive to Object <-boxing

           // var i = (int) l[0];//<-- object to primitive type conversion Unboxing 
      }
   }
   }
