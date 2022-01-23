using HRDB;
using HREntity;
using HRModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRRepository
{
    public class ApplicationRepository : IApplicationRepository
    {
     

   public HrSystemDBContext HrSystemDBContext { get; set; } //Instance variable 

       


        public ApplicationRepository (HrSystemDBContext hrSystemDBContext)
        {
        
         HrSystemDBContext = hrSystemDBContext;
        }

        private string _query = @"Select   a.id, FirstName, MiddleName, LastName, Email, Phone, Gender, Address, a.Experience, a.Status, Resume, VacancyId, StageId, DateCreated   
                        from [dbo].[application] a 
                        inner join [dbo].[Stage] s  on s.id=a.StageId
                        inner join [dbo].[vacancy] v on v.id=a.VacancyId
                        Where 1=1  ";

    

      private string _queryCount = @"Select   count(1) as countValue   
                        from [dbo].[application] a 
                        inner join [dbo].[Stage] s  on s.id=a.StageId
                        inner join [dbo].[vacancy] v on v.id=a.VacancyId
                        Where 1=1  ";

        public Application Save(Application application)
        {
            if (application.Id == 0 || application.Id is null)
            {
                HrSystemDBContext.Applications.Add(application);
            }
            else
            {
                HrSystemDBContext.Attach(application);
                HrSystemDBContext.Entry(application).State = EntityState.Modified;
            }
         //var Application = new Application()
         ////{
         ////   Resume = Save(application.Resume)
         //};
         //HrSystemDBContext.Applications.Add(application);
         HrSystemDBContext.SaveChanges();

            return application;
        }
      

        public void Delete(Application application)
        {
            HrSystemDBContext.Remove(application);

            HrSystemDBContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var application = Get(id);
            if (!(application is null))
            {
                Delete(application);
            }
        }

        public Application Get(int id)
        {
            return HrSystemDBContext.Applications.FirstOrDefault(x => x.Id == id);
        }
     //public Application Upload(Application application)
     // {
     //    var Application = new Application()
     //    {
     //       Resume = Save(application.Resume)
     //    };
     //    re
     // }


      public List<Application> GetAll(string columnName, string orderBy, string IdSearch, string NameSearch, PageModel pageModel)
        {
            return null;
        }


        public List<Application> GetAll(ApplicationModel applicationModel, PageModel pageModel) //parameter 
        {
            string columnName = applicationModel.ColumnName; //local variable
            string orderBy = applicationModel.OrderBy;

            HrSystemDBContext.Count = HrSystemDBContext.Count + 1;


            string where = applicationModel.Where();
            string sort = applicationModel.Sort();

            var dbCOnnection = HrSystemDBContext.Database.GetDbConnection();
            if (dbCOnnection.State != System.Data.ConnectionState.Open)
            {
                dbCOnnection.Open();
            }

            var dbCOmmand = dbCOnnection.CreateCommand();
            dbCOmmand.CommandText = _queryCount + where;

            var rowsCount = (int)dbCOmmand.ExecuteScalar();

            string page = "";


            if (!(pageModel is null))
            {
                page = pageModel.SetValues(rowsCount);
            }

            var lstApplication = HrSystemDBContext.Applications.FromSqlRaw(_query + where + sort + page).ToList();
            return lstApplication.ToList();
        }


        public List<Application> GetAllWIthEntity(ApplicationModel applicationModel, PageModel pageModel)
        {
            string columnName = applicationModel.ColumnName;
            string orderBy = applicationModel.OrderBy;

            

            var lstApplication = applicationModel.Where(HrSystemDBContext.Applications.Include("Vacancy").Include("Stage"));
            lstApplication = applicationModel.Sort(lstApplication);


            if (!(pageModel is null))
            {
                pageModel.SetValues(lstApplication.ToList());
                lstApplication = lstApplication.Skip(pageModel.StartIndex).Take(pageModel.RowPerPage).ToList();

            }


            return lstApplication.ToList();
        }

        public List<Application> GetAll(ApplicationModel applicationModel)
        {
            string columnName = applicationModel.ColumnName;
            string orderBy = applicationModel.OrderBy;



            var lstApplication = applicationModel.Where(HrSystemDBContext.Applications.Include("Vacancy").Include("Stage"));
            lstApplication = applicationModel.Sort(lstApplication);


            


            return lstApplication.ToList();
        }



    }
}
