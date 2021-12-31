using HREntity;
using HRModels;
using HRRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRService
{
    public class ApplicationService
    {
        ApplicationRepository ApplicationRepository = new ApplicationRepository();
        VacancyRepository VacancyRepository = new VacancyRepository();
        public List<Application> GetAll(ApplicationModel applicationModel, PageModel pageModel)
        {
             var lstApplication= ApplicationRepository.GetAll(applicationModel, pageModel);
            lstApplication = VacancyRepository.SetVacancies(lstApplication).ToList();

            return lstApplication;
        }


        public Application Get(int id)
        {
            return ApplicationRepository.Get(id);
        }
    }
}
