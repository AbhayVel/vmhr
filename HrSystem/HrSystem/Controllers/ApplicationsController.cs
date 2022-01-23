using HREntity;
using HRModels;
using HRService;
using HrSystem.FIlters;
using HrSystem.Models;

using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Authorization;

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


      public ApplicationsController(ApplicationService applicationService,
          VacancyService vacancyService

          )
      {
         ApplicationService = applicationService;
         VacancyService = vacancyService;

      }


      public IActionResult Index2()
      {
         ApplicationModel applicationModel = new ApplicationModel();
         TryUpdateModelAsync(applicationModel);
         PageModel pageModel = new PageModel();
         TryUpdateModelAsync(pageModel);



         var lstApplication = ApplicationService.GetAll(applicationModel, pageModel);

         ViewBag.orderBy = applicationModel.OrderBy;
         ViewBag.columnName = applicationModel.ColumnName;
         ViewBag.applicationModel = applicationModel;
         ViewBag.pageModel = pageModel;

         return View("Index", lstApplication);
      }



      public IActionResult Index(ApplicationModel applicationModel, PageModel pageModel)
      {


         var lstApplication = ApplicationService.GetAll(applicationModel, pageModel);

         ViewBag.orderBy = applicationModel.OrderBy;
         ViewBag.columnName = applicationModel.ColumnName;
         ViewBag.applicationModel = applicationModel;
         ViewBag.pageModel = pageModel;

         return View("Index", lstApplication);
      }

      public IActionResult Jquery()
      {
         //ApplicationModel applicationModel = new ApplicationModel();
         //PageModel pageModel = null;

         //var lstApplication = ApplicationService.GetAll(applicationModel, pageModel);

         //ViewBag.orderBy = applicationModel.OrderBy;
         //ViewBag.columnName = applicationModel.ColumnName;


         return View();
      }

      public IActionResult GetJSonData()
      {
         ApplicationModel applicationModel = new ApplicationModel();
         PageModel pageModel = null;

         var lstApplication = ApplicationService.GetAll(applicationModel, pageModel);

         return Json(lstApplication);
      }






      [HRRoleAuthorization(Roles = "manager, hr, Admin")]
      public IActionResult Add()

      {
         var application = new Application();

         application.VacancyId = 1;
         var vacancyList = VacancyService.GetWithSelect();

         ViewBag.VacancyId = vacancyList.Select(x => new SelectListItem(x.Position, x.Id.ToString()));
         return View("Add", application);
      }


      public IActionResult Delete(int id)
      {
         var application = ApplicationService.Get(id);
         if (application == null)
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
         ViewBag.VacancyId = vacancyList.Select(x => new SelectListItem(x.Position, x.Id.ToString()));


         return View("add", application);
      }


      [HRRoleAuthorization(Roles = "manager, hr, Admin")]
      [HttpPost]
      public IActionResult Save(Application application, IFormFile file)
      {
         TryValidateModel(application);
         if (!ModelState.IsValid)
         {
            return View("Add", application);
         }


         ApplicationService.Save(application);
         if (file != null)
         {
            var name = file.FileName;
            var directory = System.IO.Path.Combine(@"C:\AllFiles", application.Id.ToString());
            if (!System.IO.Directory.Exists(directory))
            {
               System.IO.Directory.CreateDirectory(directory);
            }
            var path = System.IO.Path.Combine(@"C:\AllFiles", application.Id.ToString(), name);
            //Save 
            using var stream = new FileStream(path, FileMode.Open);
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
         //  using var stream = new FileStream(path, FileMode.Open);
         byte[] fileBytes = System.IO.File.ReadAllBytes(path);
         return File(fileBytes, contentType, application.Resume);


      }

   }
}







