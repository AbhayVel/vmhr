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

      static void Main(string[] args)
      {
            
         HrSystemDBContext hrdb = new HrSystemDBContext("Data Source=DESKTOP-V4CN1TU\\SQLEXPRESS;Initial Catalog=HRSystem;Integrated Security=True");

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
