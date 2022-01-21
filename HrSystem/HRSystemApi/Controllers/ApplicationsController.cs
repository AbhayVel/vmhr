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
 [Route("api/[Controller]/[Action]/{id?}")]
    [Route("api/[Controller]")]
    [Authorize]
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
        public async Task<IActionResult> Search(ApplicationModel applicationModel)
        { 

            

            var lstApplication = ApplicationService.GetAll(applicationModel);

            applicationModel.Applications = lstApplication;

            //if(lstApplication.Count == 0)
            //{
            //    return NoContent();
            //}

            return Ok(applicationModel);
        }



        [HttpDelete]         
        public async Task<IActionResult> Delete(int id)
        {
            var application = ApplicationService.Get(id);
            if(application == null)
            {
                //  return NotFound();

                return BadRequest();
            }


            ApplicationService.Delete(id);
            return Ok("User is deleted");
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var application = ApplicationService.Get(id);
            if (application == null)
            {
                return NotFound();
            }


            
            return Ok(application);
        }





        [HttpPost]
        public async Task<IActionResult>  Save(Application application)
        {

            if (!ModelState.IsValid)
            {
               // return Ok(ModelState);

                return ValidationProblem(ModelState);
            }


            ApplicationService.Save(application);
            //Save 
            return Ok(application);
        }


             
     
    }
}
