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
        StageRepository StageRepository = new StageRepository();
        public List<Application> GetAll(ApplicationModel applicationModel, PageModel pageModel)
        {
             var lstApplication= ApplicationRepository.GetAll(applicationModel, pageModel);
            lstApplication = StageRepository.SetStages(lstApplication).ToList();
            lstApplication = VacancyRepository.SetVacancies(lstApplication).ToList();

            return lstApplication;
        }

        public Application Save(Application application)
        {
            return ApplicationRepository.Save(application);
        }

        public void Delete(Application application)
        {
              ApplicationRepository.Delete(application);
        }

        public void Delete(int id)
        {
              ApplicationRepository.Delete(id);
        }


        public Application Get(int id)
        {
            return ApplicationRepository.Get(id);
        }
    }
}
