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
                Name = "Niikita3",
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

            lstApplication.Add(new Application
            {
                Id = 11,
                Name = "vijay2",
                AppliedFor = "MVC.net",
                Experience = "1year",
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
