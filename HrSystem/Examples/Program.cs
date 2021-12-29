using HRDB;
using HREntity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Examples
{
    class Program
    {
      private static Application application;

      static void Main(string[] args)
        {

            HrSystemDBContext hrdb = new HrSystemDBContext();

          //  var data = hrdb.Users.ToList();

          //User user=  hrdb.Users.FirstOrDefault(x => x.UserId == 2);

         var Adata = hrdb.Applications.ToList();

         //Application application = hrdb.Applications.FirstOrDefault(x => x.Id==4);
         //application.FirstName = "abi";
         //hrdb.SaveChanges();
         //Application application = new Application
         //{
         //   FirstName = "suraj",
         //   MiddleName = "D",
         //   LastName = "Bhendawade",
         //   Gender = "M",
         //   Email = "surj@gmail.com",
         //   Phone = "090990",
         //   Address = "kolhapur",
         //   Resume = "upload",
         //   AppliedFor = ".net",
         //   Experience = "1",
         //   DateCreated =  DateTime.Now,
         //   Status = "active"

         //};
         //hrdb.Applications.Add(application);
         //hrdb.SaveChanges();

         application = hrdb.Applications.FirstOrDefault(x => x.Id == 5);
         hrdb.Applications.Remove(application);
         hrdb.SaveChanges();

         //user.Password = "xyz";
         //hrdb.SaveChanges();
         //user = hrdb.Users.FirstOrDefault(x => x.UserId == 3);
         //hrdb.Users.Remove(user);
         //hrdb.SaveChanges();
         //User user = new User
         //{
         //    Name = "AV",
         //    address = "a",
         //    Type = 1,
         //    UserName = "aa",
         //    Action = "Active",
         //    contact = "a",
         //    Password = "abc"
         //};

         //hrdb.Users.Add(user);
         //hrdb.SaveChanges();







      }


      public static Tuple<bool,bool> IsAdultAndCanMarry(int age, string gender)
        {
            bool isAdult = false;
            bool isMarry = false;

            if (age > 18)
            {
                isAdult = true;
            }
            else
            {
                isAdult = false;
            }
            if (age > 18 && "F".Equals(gender))
            {

                isMarry =true;
            }
            if (age > 21 && "M".Equals(gender))
            {
                isMarry= true;
            }

            Tuple<bool,bool> result= new Tuple<bool,bool>(isAdult,isMarry);
            return result;

        }
            public static bool IsAdultAndCanMarry(int age, string gender, out bool isAdult)
        {
            if(age > 18)
            {
                isAdult = true;
            }else
            {
                isAdult = false;
            }
            if(age> 18 && "F".Equals(gender))
            {
                
                return true;
            }
            if (age > 21 && "M".Equals(gender))
            {
                return true;
            }

            return false;




            return false;
            
        }
    }
}
