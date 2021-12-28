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
                FirstName = "Abhijeet",
                
                Experience = 5,
                Status = "Active"
            });




            lstApplication.Add(new Application
            {
                Id = 2,
                FirstName = "Other",
                
                Experience = 3,
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 3,
                FirstName = "Nikita",
                
                Experience = 3,
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 4,
                FirstName = "Nikita2",
                
                Experience = 3,
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 5,
                FirstName = "Niikita3",
                
                Experience = 3,
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 6,
                FirstName = "Nikita4",
                
                Experience = 3,
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 7,
                FirstName = "Abhijeet2",
               
                Experience = 1,
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 8,
                FirstName = "Abhijeet3",
               
                Experience = 1,
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 9,
                FirstName = "Abhijeet4",
               
                Experience = 1,
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 10,
                FirstName = "Amay",
               
                Experience = 1,
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 11,
                FirstName = "vijay",
               
                Experience = 1,
                Status = "Active"
            });

            lstApplication.Add(new Application
            {
                Id = 11,
                FirstName = "vijay2",
               
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
