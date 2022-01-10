using HREntity;
using HRModels;
using HRService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSystemApi.Controllers
{

    [ApiController]
 [Route("[Controller]/[Action]")]
    [Route("[Controller]")]
    public class ApplicationsController : ControllerBase
    {

        ApplicationService ApplicationService { get; set; }
        VacancyService VacancyService { get; set; }
        StageService StageService { get; set; }

        public ApplicationsController(ApplicationService applicationService,
            VacancyService vacancyService,
            StageService stageService

            )
        {
            ApplicationService = applicationService;
            VacancyService = vacancyService;
            StageService = stageService;
        }

  
        [HttpGet]
        public ApplicationModel Index()
        {

            ApplicationModel applicationModel = new ApplicationModel();
           
            var lstApplication = ApplicationService.GetAll(applicationModel);

            applicationModel.Applications = lstApplication;

            return applicationModel;
        }


        [HttpPost]
        public ApplicationModel Search(ApplicationModel applicationModel)
        {

            

            var lstApplication = ApplicationService.GetAll(applicationModel);

            applicationModel.Applications = lstApplication;

            return applicationModel;
        }




        public IActionResult Delete(int id)
        {
            var application = ApplicationService.Get(id);
            if(application == null)
            {
                return Redirect("/applications/index");
            }


            ApplicationService.Delete(id);
            return Redirect("/applications/index");
        }

         
         


        
        [HttpPost]
        public Application Save(Application application)
        {

            if (!ModelState.IsValid)
            {
                return application;
            }


            ApplicationService.Save(application);
            //Save 
            return application;
        }


             
     
    }
}
