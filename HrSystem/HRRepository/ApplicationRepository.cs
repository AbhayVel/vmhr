using HRDB;
using HREntity;
using HRModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRRepository
{
    public class ApplicationRepository
    {

        string Query = @"Select   a.id, FirstName, MiddleName, LastName, Email, Phone, Gender, Address, a.Experience, a.Status, Resume, VacancyId, StageId, DateCreated   
                        from [dbo].[application] a 
                        inner join [dbo].[Stage] s  on s.id=a.StageId
                        inner join [dbo].[vacancy] v on v.id=a.VacancyId
                        Where 1=1  ";

        string QueryCount = @"Select   count(1) as countValue   
                        from [dbo].[application] a 
                        inner join [dbo].[Stage] s  on s.id=a.StageId
                        inner join [dbo].[vacancy] v on v.id=a.VacancyId
                        Where 1=1  ";

        public Application Save(Application application)
        {
            if (application.Id == 0 || application.Id is null)
            {
                hrSystemDBContext.Applications.Add(application);
            } else
            {
                hrSystemDBContext.Attach(application);
                hrSystemDBContext.Entry(application).State = EntityState.Modified;
            }

            hrSystemDBContext.SaveChanges();

            return application;
        }

        public void Delete(Application application)
        {
            hrSystemDBContext.Remove(application);

            hrSystemDBContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var application = Get(id);
            if (!(application is  null))
            {
                Delete(application);
            }
        }

        public Application Get(int id)
        {
            return hrSystemDBContext.Applications.FirstOrDefault(x => x.Id == id);
        }

        HrSystemDBContext hrSystemDBContext = new HrSystemDBContext();
     public   ApplicationRepository()
        {

        }
        public List<Application> GetAll(string columnName, string orderBy, string IdSearch, string NameSearch, PageModel pageModel)
        {
            return null;
        }


        public List<Application> GetAll(ApplicationModel applicationModel, PageModel pageModel)
        {
            string columnName = applicationModel.ColumnName;
            string orderBy = applicationModel.OrderBy;

            ;


            string where = applicationModel.Where();
            string sort = applicationModel.Sort();

         var dbCOnnection=   hrSystemDBContext.Database.GetDbConnection();
            if(dbCOnnection.State != System.Data.ConnectionState.Open)
            {
                dbCOnnection.Open();
            }
          
            var dbCOmmand = dbCOnnection.CreateCommand();
            dbCOmmand.CommandText = QueryCount + where;

          var rowsCount=(int)  dbCOmmand.ExecuteScalar();

            string page = "";








            if (!(pageModel is null))
            {               
                page = pageModel.SetValues(rowsCount);
            }

            var lstApplication = hrSystemDBContext.Applications.FromSqlRaw(Query + where + sort + page ).ToList();
            return lstApplication.ToList();
        }




        public List<Application> GetAllWIthEntity(ApplicationModel applicationModel, PageModel pageModel)
        {
            string columnName = applicationModel.ColumnName;
            string orderBy = applicationModel.OrderBy;

            ;

           var  lstApplication = applicationModel.Where(hrSystemDBContext.Applications.Include("Vacancy").Include("Stage"));
            lstApplication = applicationModel.Sort(lstApplication);


            if (!(pageModel is  null))
            {
                pageModel.SetValues(lstApplication.ToList());
                lstApplication = lstApplication.Skip(pageModel.StartIndex).Take(pageModel.RowPerPage).ToList();

            }


            return lstApplication.ToList();
        }
    }
}
