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
            
         HrSystemDBContext hrdb = new HrSystemDBContext();

            ArrayList l = new ArrayList();

           List<string> lst= new List<string>();
             
            l.Add(2); ///<- primitive to Object <-boxing

            var i = (int) l[0];//<-- object to primitive type conversion Unboxing 
      }
   }
   }
