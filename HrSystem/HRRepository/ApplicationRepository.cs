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
