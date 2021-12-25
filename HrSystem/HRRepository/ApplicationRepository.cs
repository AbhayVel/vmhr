using HREntity;
using HRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRRepository
{
   public class ApplicationRepository
    {

        public List<Application> GetAll(string columnName, string orderBy, string IdSearch, string NameSearch, PageModel pageModel)
        {
            return null;
        }

            public List<Application> GetAll(ApplicationModel applicationModel, PageModel pageModel)
        {
            string columnName = applicationModel.ColumnName;
            string orderBy = applicationModel.OrderBy;

            List<Application> lstApplication = new List<Application>();

            lstApplication.Add(new Application
            {
                Id = 1,
                FullName = "Abhijeet",
                AppliedFor = "MVC.net",
                Experience = 5,
                Status = "Active"
            });




            lstApplication.Add(new Application
            {
                Id = 2,
                FullName = "Other",
                AppliedFor = "web",
                Experience = 3,
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 3,
                FullName = "Nikita",
                AppliedFor = "web",
                Experience = 3,
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 4,
                FullName = "Nikita2",
                AppliedFor = "web",
                Experience = 3,
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 5,
                FullName = "Niikita3",
                AppliedFor = "web",
                Experience = 3,
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 6,
                FullName = "Nikita4",
                AppliedFor = "web",
                Experience = 3,
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 7,
                FullName = "Abhijeet2",
                AppliedFor = "MVC.net",
                Experience = 1,
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 8,
                FullName = "Abhijeet3",
                AppliedFor = "MVC.net",
                Experience = 1,
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 9,
                FullName = "Abhijeet4",
                AppliedFor = "MVC.net",
                Experience = 1,
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 10,
                FullName = "Amay",
                AppliedFor = "MVC.net",
                Experience = 1,
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 11,
                FullName = "vijay",
                AppliedFor = "MVC.net",
                Experience = 1,
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 11,
                FullName = "vijay2",
                AppliedFor = "MVC.net",
                Experience = 1,
                Status = "Active"
            });


            lstApplication = applicationModel.Where(lstApplication).ToList();
            lstApplication = applicationModel.Sort(lstApplication).ToList();


            if (!(pageModel is  null))
            {
                pageModel.SetValues(lstApplication);
                lstApplication = lstApplication.Skip(pageModel.StartIndex).Take(pageModel.RowPerPage).ToList();

            }


            return lstApplication;
        }
    }
}
