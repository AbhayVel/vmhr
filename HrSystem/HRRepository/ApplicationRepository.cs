﻿using HREntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRRepository
{
   public class ApplicationRepository
    {

        public List<Application> GetAll(string columnName, string orderBy)
        {

            List<Application> lstApplication = new List<Application>();

            lstApplication.Add(new Application
            {
                Id = 1,
                Name = "Abhijeet",
                AppliedFor = "MVC.net",
                Experience = "1year",
                Status = "Active"
            });




            lstApplication.Add(new Application
            {
                Id = 2,
                Name = "Other",
                AppliedFor = "web",
                Experience = "3years",
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 3,
                Name = "Nikita",
                AppliedFor = "web",
                Experience = "3years",
                Status = "Active"
            });

           

            if ("name".Equals(columnName, StringComparison.OrdinalIgnoreCase))
            {
                if (orderBy.Equals("asc"))
                {
                    lstApplication = lstApplication.OrderBy(x => x.Name).ToList();
                }
                else
                {
                    lstApplication = lstApplication.OrderByDescending(x => x.Name).ToList();
                }
            }

            if ("id".Equals(columnName, StringComparison.OrdinalIgnoreCase))
            {
                if (orderBy.Equals("asc"))
                {
                    lstApplication = lstApplication.OrderBy(x => x.Id).ToList();
                }
                else
                {
                    lstApplication = lstApplication.OrderByDescending(x => x.Id).ToList();
                }
            }


            return lstApplication;
        }
    }
}