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
        IApplicationRepository ApplicationRepository { get; set; }
        VacancyRepository VacancyRepository { get; set; }
        StageRepository StageRepository { get; set; }

        public ApplicationService(IApplicationRepository applicationRepository,

            VacancyRepository vacancyRepository,
            StageRepository stageRepository

            )
        {
            ApplicationRepository = applicationRepository;
            VacancyRepository = vacancyRepository;
            StageRepository = stageRepository;
            
        }

        public List<Application> GetAll(ApplicationModel applicationModel)
        {
            if (applicationModel == null)
            {
                applicationModel = new ApplicationModel();
            }            

            return GetAll(applicationModel,applicationModel.PageModel) ;
        }

        public List<Application> GetAll(ApplicationModel applicationModel, PageModel pageModel)
        {
             var lstApplication= ApplicationRepository.GetAll(applicationModel, pageModel);
            lstApplication = StageRepository.SetStages(lstApplication).ToList();
            lstApplication = VacancyRepository.SetVacancies(lstApplication).ToList();

            return lstApplication;
        }

        public List<Application> GetWithSelect()

        {
            var lst = GetAll(new ApplicationModel(), null);

            lst.Insert(0, new Application { Id = 0, Gender = "Select" });
            return lst;
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
      //public List<Application> GetWithSelect()

      //{
      //   var lst = GetAll(new ApplicationModel(), null);

      //   lst.Insert(0, new Application { Id = 0, Gender = "Select" });
      //   return lst;
      //}
   }
}
