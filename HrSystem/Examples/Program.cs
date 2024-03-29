﻿using HRDB;
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

            

           // ArrayList l = new ArrayList();

           //List<string> lst= new List<string>();
             
           // l.Add(2); ///<- primitive to Object <-boxing

           // var i = (int) l[0];//<-- object to primitive type conversion Unboxing 
      }
   }
   }
