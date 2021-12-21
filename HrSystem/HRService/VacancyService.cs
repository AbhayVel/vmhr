using HREntity;
using HRModels;
using HRRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRService
{
    public class VacancyService
    {
        VacancyRepository VacancyRepository = new HRRepository.VacancyRepository();
        public List<Vacancy> GetAll(VacancyModel vacancyModel, PageModel pageModel)

        {
            return VacancyRepository.GetAll(vacancyModel,pageModel);
        }

       
    }

}