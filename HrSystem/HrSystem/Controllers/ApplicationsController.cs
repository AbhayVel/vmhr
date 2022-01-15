﻿using HREntity;
using HRModels;
using HRService;
using HrSystem.FIlters;
using HrSystem.Models;
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

    [HRActionFilter]
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
        public IActionResult Save(Application application, IFormFile file)
        {

            if (!ModelState.IsValid)
            {
                return View("Add", application);
            }


            ApplicationService.Save(application);
         if(file != null)
         {
            var name = file.FileName;
            var directory = System.IO.Path.Combine(@"C:\AllFiles", application.Id.ToString());
            if (!System.IO.Directory.Exists(directory))
            {
               System.IO.Directory.CreateDirectory(directory);
            }
            var path = System.IO.Path.Combine(@"C:\AllFiles", application.Id.ToString(), name);
            //Save 
            using var stream = new FileStream(path, FileMode.CreateNew);
            file.CopyTo(stream);
            application.Resume = name;
            ApplicationService.Save(application);
         }
         
         return Redirect("/applications/index");
        }

      public IActionResult Download(int id)
      {

         var application = ApplicationService.Get(id);

         if (application == null)
         {
            return NotFound();
         }

         var directory = System.IO.Path.Combine(@"C:\AllFiles");
         var path = System.IO.Path.Combine(@"C:\AllFiles", application.Id.ToString(), application.Resume);

         ////Save 
         //using var stream = new FileStream(path, FileMode.Open);
         string contentType = "application/pdf";
         if (path.Contains(".pdf"))
         {
            contentType = "application/pdf";
         }
         else if (path.Contains(".docx"))
         {
            contentType = "application/docx";
         }
         else if (path.Contains(".txt"))
         {
            contentType = "application/txt";
         }
         byte[] fileBytes = System.IO.File.ReadAllBytes(path);
         return File(fileBytes, contentType, application.Resume);


      }
      
            }
   }



//public IActionResult Jquery(ApplicationModel applicationModel)
//{

//   var lstApplication = ApplicationService.GetAll(applicationModel, null);


//   return View(lstApplication);
//}



