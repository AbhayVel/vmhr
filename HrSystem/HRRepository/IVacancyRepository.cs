using HRDB;
using HREntity;
using HRModels;
using System.Collections.Generic;

namespace HRRepository
{
    public interface IVacancyRepository
    {
        HrSystemDBContext HrSystemDBContext { get; set; }
        int TotalRowCount { get; }

        void Delete(int id);
        void Delete(Vacancy vacancy);
        Vacancy Get(int id);
        List<Vacancy> GetAll(VacancyModel vacancyModel, PageModel pageModel);
        Vacancy Save(Vacancy vacancy);
        IEnumerable<T> SetVacancies<T>(IEnumerable<T> lstIVacancy) where T : IVacancy;
    }
}