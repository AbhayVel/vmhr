using HREntity;
using HRModels;
using HRService;
using HrSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrSystem.Controllers
{
    public class ApplicationsController : Controller
    {

        ApplicationService ApplicationService = new ApplicationService();
        VacancyService VacancyService = new VacancyService();
        StageService StageService = new StageService();
        public IActionResult Index(ApplicationModel applicationModel, PageModel pageModel)
        {
         
            pageModel.RowPerPage = 4;
            var lstApplication = ApplicationService.GetAll(applicationModel,pageModel);

            ViewBag.orderBy = applicationModel.OrderBy;
            ViewBag.columnName = applicationModel.ColumnName;
            ViewBag.applicationModel = applicationModel;
            ViewBag.pageModel = pageModel;

            return View("Index",lstApplication);
        }

        public IActionResult Add()
        {
            var application = new Application();

             
            var vacancyList = VacancyService.GetWithSelect();
            var stageList = StageService.GetWithSelect();
            ViewBag.VacancyId = vacancyList.Select(x => new SelectListItem(x.Position, x.Id.ToString()));
            ViewBag.StageId = stageList.Select(x => new SelectListItem(x.StatusLabel, x.Id.ToString()));
            return View(application);
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
