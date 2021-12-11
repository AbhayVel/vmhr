﻿using HREntity;
using HRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRRepository
{
   public class ApplicationRepository
    {

        public List<Application> GetAll(string columnName, string orderBy, PageModel pageModel)
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

            lstApplication.Add(new Application
            {
                Id = 4,
                Name = "Nikita2",
                AppliedFor = "web",
                Experience = "3years",
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 5,
                Name = "Nikita3",
                AppliedFor = "web",
                Experience = "3years",
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 6,
                Name = "Nikita4",
                AppliedFor = "web",
                Experience = "3years",
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 7,
                Name = "Abhijeet2",
                AppliedFor = "MVC.net",
                Experience = "1year",
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 8,
                Name = "Abhijeet3",
                AppliedFor = "MVC.net",
                Experience = "1year",
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 9,
                Name = "Abhijeet4",
                AppliedFor = "MVC.net",
                Experience = "1year",
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 10,
                Name = "Amay",
                AppliedFor = "MVC.net",
                Experience = "1year",
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 11,
                Name = "vijay",
                AppliedFor = "MVC.net",
                Experience = "1year",
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

            if(!(pageModel is  null))
            {
                pageModel.TotalRowCount = lstApplication.Count;

                int pageCount =(int)Math.Ceiling( pageModel.TotalRowCount* 1.0 / pageModel.RowPerPage*1.0);

                int startIndex = (pageModel.CurrentPage - 1) * pageModel.RowPerPage;

                 
                int endIndex = startIndex + pageModel.RowPerPage -1;
                if(endIndex > pageModel.TotalRowCount - 1)
                {
                    endIndex = pageModel.TotalRowCount - 1;
                }

                pageModel.StartIndex = startIndex;
                pageModel.PageCount = pageCount;
                pageModel.EndIndex = endIndex;
                lstApplication = lstApplication.Skip(pageModel.StartIndex).Take(pageModel.RowPerPage).ToList();

            }


            return lstApplication;
        }
    }
}
