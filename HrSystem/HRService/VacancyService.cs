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
        VacancyRepository VacancyRepository { get; set; }
        public List<Vacancy> GetAll(VacancyModel vacancyModel, PageModel pageModel)

        {
            return VacancyRepository.GetAll(vacancyModel,pageModel);
        }


        public List<Vacancy> GetWithSelect()

        {
            var lst= GetAll(new VacancyModel(), null);

            lst.Insert(0, new Vacancy { Id = 0, Position = "Select" });
            return lst;
        }

    }

}