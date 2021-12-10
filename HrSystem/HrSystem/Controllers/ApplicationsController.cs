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
        public IActionResult Index(ApplicationModel applicationModel)
        {

            var lstApplication = ApplicationService.GetAll(applicationModel.ColumnName, applicationModel.OrderBy);

            if ("asc".Equals(applicationModel.OrderBy))
            {
                applicationModel.OrderBy = "desc";
            } else
            {
                applicationModel.OrderBy = "asc";
            }


            ViewBag.orderBy = applicationModel.OrderBy;

            return View(lstApplication);
        }



        public IActionResult Jquery()
        {

            List<Application> lstApplication = new List<Application>();

            lstApplication.Add(new Application
            {
                Id = 1,
                Name = "Abhijeet",
                AppliedFor = "MVC.net",
                Experience = "1year",
                Status = "Active"
            });


            lstApplication.Add(new Application
            {
                Id = 2,
                Name = "Nikita",
                AppliedFor = "web",
                Experience = "3years",
                Status = "Active"
            });


            lstApplication.Add(new Application
            {
                Id = 3,
                Name = "Other",
                AppliedFor = "web",
                Experience = "3years",
                Status = "Active"
            });

            return View(lstApplication);
        }
    }
}
