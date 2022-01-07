
using System;
using HREntity;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HRModels;
using HRDB;
using Microsoft.EntityFrameworkCore;

namespace HRRepository
{
   public  class VacancyRepository
    {
        HrSystemDBContext hrSystemDBContext = new HrSystemDBContext();

        public VacancyRepository()
        { 
        }
        

        public int TotalRowCount { get; private set; }

        public List<Vacancy>  GetAll(VacancyModel vacancyModel, PageModel pageModel)
        {
            string ColumnName = vacancyModel.ColumnName;
            string OrderBy = vacancyModel.OrderBy;
           // var lstVacancy = hrSystemDBContext.Vacancies;
             var lstVacancy = vacancyModel.Where(hrSystemDBContext.Vacancies);
            lstVacancy = vacancyModel.Sort(lstVacancy);

            if (!(pageModel is null))
            {
                pageModel.SetValues(lstVacancy.ToList());
                lstVacancy = lstVacancy.Skip(pageModel.StartIndex).Take(pageModel.RowPerPage);
            }
            return lstVacancy.ToList();
        }

        public Vacancy Get(int id)
        {
            return hrSystemDBContext.Vacancies.FirstOrDefault(x=>x.Id==id);
        }

        public IEnumerable<T> SetVacancies<T>(IEnumerable<T> lstIVacancy) where T : IVacancy
        {
            var lstVacanyIds = lstIVacancy.Select(x => x.VacancyId).Distinct().ToList();

          var lstVacancy = hrSystemDBContext.Vacancies.Where(x => lstVacanyIds.Contains(x.Id)).ToList();

            foreach (var item in lstIVacancy)
            {
                item.Vacancy = lstVacancy.FirstOrDefault(x => x.Id == item.VacancyId);
            }

            return lstIVacancy;
        }

        public Vacancy Save(Vacancy vacancy)
        {
            if (vacancy.Id == 0 || vacancy.Id is null)
            {
                hrSystemDBContext.Vacancies.Add(vacancy);
            }
            else
            {
                hrSystemDBContext.Attach(vacancy);
                hrSystemDBContext.Entry(vacancy).State = EntityState.Modified;
            }

            hrSystemDBContext.SaveChanges();

            return vacancy;
        }


    }
}
