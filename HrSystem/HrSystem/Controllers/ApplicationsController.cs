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
        public IActionResult Index()
        {

            List<Application> lstApplication = new List<Application>();

            lstApplication.Add(new Application
            {
                Id = 1,
                Name="Abhijeet",
                AppliedFor="MVC.net",
                Experience="1year",
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
