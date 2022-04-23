using HRModels;
using HRService;
using HrSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HrSystem.Controllers
{
    public class HomeController : Controller
    {
      ApplicationService ApplicationService { get; set; }
      StageService StageService { get; set; }
      public HomeController(ApplicationService applicationService, StageService stageService)
      {
         ApplicationService = applicationService;
         StageService = stageService;

      }
      private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
         //var stageList = StageService.GetWithSelect();
         //ViewBag.StageId = stageList.Select(x => new (x.StatusLabel, x.Id.ToString()));
         
         return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
