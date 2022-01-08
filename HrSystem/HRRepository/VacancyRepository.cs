
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
    public class VacancyRepository : IVacancyRepository
    {
        public HrSystemDBContext HrSystemDBContext { get; set; }

        public VacancyRepository(HrSystemDBContext hrSystemDBContext)
        {
            HrSystemDBContext = hrSystemDBContext;
        }

        public int TotalRowCount { get; private set; }


        public List<Vacancy> GetAll(VacancyModel vacancyModel, PageModel pageModel)
        {
            string ColumnName = vacancyModel.ColumnName;
            string OrderBy = vacancyModel.OrderBy;
            HrSystemDBContext.Count = HrSystemDBContext.Count + 1;
            // var lstVacancy = hrSystemDBContext.Vacancies;
            var lstVacancy = vacancyModel.Where(HrSystemDBContext.Vacancies);
            lstVacancy = vacancyModel.Sort(lstVacancy);

            if (!(pageModel is null))
            {
                pageModel.SetValues(lstVacancy.ToList());
                lstVacancy = lstVacancy.Skip(pageModel.StartIndex).Take(pageModel.RowPerPage);
            }
            return lstVacancy.ToList();
        }

        public void Delete(Vacancy vacancy)
        {

            HrSystemDBContext.Remove(vacancy);
            HrSystemDBContext.SaveChanges();
        }




        public void Delete(int id)
        {
            var vacancy = Get(id);
            if (!(vacancy is null))
            {
                Delete(vacancy);
            }
        }


        public Vacancy Save(Vacancy vacancy)
        {
            if (vacancy.Id == 0 || vacancy.Id is null)
            {
                HrSystemDBContext.Vacancies.Add(vacancy);
            }
            else
            {
                HrSystemDBContext.Attach(vacancy);
                HrSystemDBContext.Entry(vacancy).State = EntityState.Modified;
            }

            HrSystemDBContext.SaveChanges();

            return vacancy;
        }

        public Vacancy Get(int id)
        {
            return HrSystemDBContext.Vacancies.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> SetVacancies<T>(IEnumerable<T> lstIVacancy) where T : IVacancy
        {
            var lstVacanyIds = lstIVacancy.Select(x => x.VacancyId).Distinct().ToList();
            HrSystemDBContext.Count = HrSystemDBContext.Count + 1;
            var lstVacancy = HrSystemDBContext.Vacancies.Where(x => lstVacanyIds.Contains(x.Id)).ToList();

            foreach (var item in lstIVacancy)
            {
                item.Vacancy = lstVacancy.FirstOrDefault(x => x.Id == item.VacancyId);
            }

            return lstIVacancy;
        }



    }
}
