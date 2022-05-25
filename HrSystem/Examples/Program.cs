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

      static  void Print(IName iname)
        {
            Console.WriteLine(iname.Name);
        }

        //composition
        //Association
        //Messeging 
        //Association+ Interface =>Dependency Inversion =>IOC
        //||-> Dependency Injection -> Static /compile time 
        //||-> 
        //||-> Service Locator -> Dynamic /run time 


        static int i = 1;
      static void Main(string[] args)
      {
            
         var output=   Translet("sun shines");
            Address address= new Address();
            {

                Person person = new Person(address);
               // person.Address=address;
               person.SetAddress(address);


            }
            Print(new Location());
            //   PrintAddressName(new Location());
            if (1 == i)
            {
                Print(new Location());
            }
            else
            {
                Print(new Address());
            }
            
            

         HrSystemDBContext hrdb = new HrSystemDBContext("Data Source=DESKTOP-C0FBNF9\\SQLEXPRESS;Initial Catalog=HRSystem;Integrated Security=True");

            //hrdb.Feeds.Add(new Feed
            //{
            //    TextData = "C# Learning ",
            //    Heading = "Python",
            //    ShortNotes = "Python Learning Session",
            //    FeedTypeId = 1,
            //    Link = "#",
            //    UserName = "Aditi"
            //});

            //hrdb.Feeds.Add(new Feed
            //{
            //    TextData = "C# Learning ",
            //    Heading = "C-sharp ",
            //    ShortNotes = "Tutorial On C-Sharp",
            //    FeedTypeId = 2,
            //    Link = "#",
            //    UserName = "Avi"
            //});

            //hrdb.Feeds.Add(new Feed
            //{
            //    TextData = "UI Design",
            //    Heading = "Web Design",
            //    ShortNotes = "Learn Website design",
            //    FeedTypeId = 3,
            //    Link = "#",
            //    UserName = "Anvi"
            //});

            //hrdb.Feeds.Add(new Feed
            //{
            //    TextData = ".Net Learning",
            //    Heading = "Dot Net",
            //    ShortNotes = "ASP .Net Learning Session",
            //    FeedTypeId = 4,
            //    Link = "#",
            //    UserName = "ketaki"
            //});

            ////var feed = hrdb.FeedType.Where(x=>x.TypeText.Equals("Audio1")).FirstOrDefault();

            ////hrdb.FeedType.Remove(feed);


            //hrdb.SaveChanges();
            //var users = hrdb.Feeds.ToList();

            //foreach (var item in users)
            //{
            //    Console.WriteLine(item.TextData);
            //    Console.WriteLine(item.Heading);
            //    Console.WriteLine(item.ShortNotes);
            //    Console.WriteLine(item.FeedTypeId);
            //    Console.WriteLine(item.Link);
            //    Console.WriteLine(item.UserName);
            //}

           // ArrayList l = new ArrayList();

           //List<string> lst= new List<string>();
             
           // l.Add(2); ///<- primitive to Object <-boxing

           // var i = (int) l[0];//<-- object to primitive type conversion Unboxing 
      }
   }
   }
