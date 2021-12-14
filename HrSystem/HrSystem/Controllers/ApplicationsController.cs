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
          //  PageModel pageModel = new PageModel();
          //  pageModel.CurrentPage = 1;
            //pageModel.TotalRowCount = lstApplication.Count;
            pageModel.RowPerPage = 4;
            var lstApplication = ApplicationService.GetAll(applicationModel.ColumnName, applicationModel.OrderBy,pageModel);

            //if ("asc".Equals(applicationModel.OrderBy))
            //{
            //    applicationModel.OrderBy = "desc";
            //} else
            //{
            //    applicationModel.OrderBy = "asc";
            //}


            

            ViewBag.orderBy = applicationModel.OrderBy;
            ViewBag.columnName = applicationModel.ColumnName;

            ViewBag.pageModel = pageModel;

            return View(lstApplication);
        }



        public IActionResult Jquery(ApplicationModel applicationModel)
        {

            var lstApplication = ApplicationService.GetAll(applicationModel.ColumnName, applicationModel.OrderBy, null);


            return View(lstApplication);
        }
    }
}
