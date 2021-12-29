
using System;
using HREntity;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HRModels;
using HRDB;

namespace HRRepository
{
   


    public class VacancyRepository
    {
       HrSystemDBContext hrSystemDBContext = new HrSystemDBContext();

        public int TotalRowCount { get;set; }

        public List<Vacancy>  GetAll(VacancyModel vacancyModel, PageModel pageModel)
        {
            string ColumnName = vacancyModel.ColumnName;
            string OrderBy = vacancyModel.OrderBy;

            var lstVacancy = vacancyModel.Where(hrSystemDBContext.Vacancies);
            lstVacancy = vacancyModel.Sort(lstVacancy);

            if (!(pageModel is null))
            {
                pageModel.SetValues(lstVacancy.ToList());
                lstVacancy = lstVacancy.Skip(pageModel.StartIndex).Take(pageModel.RowPerPage).ToList();
            }
            return lstVacancy.ToList();
        }
         

    }
}
