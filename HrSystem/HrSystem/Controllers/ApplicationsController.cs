using HREntity;
using HRModels;
using HRService;
using HrSystem.FIlters;
using HrSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HrSystem.Controllers
{

 [Authorize]
    public class ApplicationsController : Controller
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

      
        public IActionResult Index(ApplicationModel applicationModel, PageModel pageModel)
        {
        

            var lstApplication = ApplicationService.GetAll(applicationModel,pageModel);

            ViewBag.orderBy = applicationModel.OrderBy;
            ViewBag.columnName = applicationModel.ColumnName;
            ViewBag.applicationModel = applicationModel;
            ViewBag.pageModel = pageModel;
        

            return View("Index",lstApplication);
        }

       

        [HRRoleAuthorization(Roles ="manager, hr, Admin")]
        public IActionResult Add()
        {
            var application = new Application();

             
            var vacancyList = VacancyService.GetWithSelect();
            var stageList = StageService.GetWithSelect();
            ViewBag.VacancyId = vacancyList.Select(x => new SelectListItem(x.Position, x.Id.ToString()));
            ViewBag.StageId = stageList.Select(x => new SelectListItem(x.StatusLabel, x.Id.ToString()));
            return View("Add",application);
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

        [HRRoleAuthorization(Roles = "manager, hr, Admin")]
        public IActionResult Edit(int id)
        {
            var application = ApplicationService.Get(id);

            if (application == null)
            {
                application = new Application();
            }


            var vacancyList = VacancyService.GetWithSelect();
            var stageList = StageService.GetWithSelect();
            ViewBag.VacancyId = vacancyList.Select(x => new SelectListItem(x.Position, x.Id.ToString()));
            ViewBag.StageId = stageList.Select(x => new SelectListItem(x.StatusLabel, x.Id.ToString()));


            return View("add",application);
        }


        [HRRoleAuthorization(Roles = "manager, hr, Admin")]
        [HttpPost]
        public IActionResult Save(Application application)
        {

            if (!ModelState.IsValid)
            {
                return View("Add", application);
            }


            ApplicationService.Save(application);
            //Save 
            return Redirect("/applications/index");
        }


            public IActionResult Jquery(ApplicationModel applicationModel)
        {

            var lstApplication = ApplicationService.GetAll(applicationModel, null);


            return View(lstApplication);
        }
     
    }
}
