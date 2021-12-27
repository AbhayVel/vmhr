using HRDB;
using HREntity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {

            HrSystemDBContext hrdb = new HrSystemDBContext();

            //var data = hrdb.Users.ToList();
            //var Vdata = hrdb.vacancies.ToList();
            var Adata = hrdb.application.ToList();

            //Application applications = new Application
            //{
            //    FirstName = "Manisha",
            //    AppliedFor = "DotNet Devoloper",
            //    Experience = 1,
            //    Status = "Active",
            //    Resume = "Manisha_Resume"
            //};

            //hrdb.application.Add(applications);
            //hrdb.SaveChanges();
            //applications = hrdb.application.FirstOrDefault(x => x.Id == 4);
            //applications.Experience=2;
            //hrdb.SaveChanges();
            //applications = hrdb.application.FirstOrDefault(x => x.Id == 15);
            //hrdb.application.Remove(applications);
            //hrdb.SaveChanges();


            /*Vacancy vacancy = new Vacancy
            {


                Position = "JavaDevoloper",
                Availability = 5,
                Description="aaaa",
                Status = "Active",
                Experience = 2,
                Skills="Java,CPP"
                
               
            };
             hrdb.vacancies.Add(vacancy);
              hrdb.SaveChanges();
                 vacancy= hrdb.vacancies.FirstOrDefault(x => x.Id == 1);

            vacancy.Availability = 10;
            hrdb.SaveChanges();
            vacancy = hrdb.vacancies.FirstOrDefault(x => x.Id == 5);
            hrdb.vacancies.Remove(vacancy);
            hrdb.SaveChanges();*/




            User user = hrdb.Users.FirstOrDefault(x => x.UserId == 2);
            user.Password = "xyz";
            hrdb.SaveChanges();
            user = hrdb.Users.FirstOrDefault(x => x.UserId == 3);
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
