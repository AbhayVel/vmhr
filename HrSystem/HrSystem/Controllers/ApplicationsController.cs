using HREntity;
using HRModels;
using HRService;
using HrSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrSystem.Controllers
{
    public class ApplicationsController : Controller
    {

        ApplicationService ApplicationService = new ApplicationService();
        public IActionResult Index(ApplicationModel applicationModel, PageModel pageModel)
        {
         
            pageModel.RowPerPage = 4;
            var lstApplication = ApplicationService.GetAll(applicationModel,pageModel);

            ViewBag.orderBy = applicationModel.OrderBy;
            ViewBag.columnName = applicationModel.ColumnName;
            ViewBag.applicationModel = applicationModel;
            ViewBag.pageModel = pageModel;

            return View(lstApplication);
        }



        public IActionResult Jquery(ApplicationModel applicationModel)
        {

            var lstApplication = ApplicationService.GetAll(applicationModel, null);


            return View(lstApplication);
        }
    }
}
