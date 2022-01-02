using HRService;
using HrSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using HREntity;
using HRModels;

namespace HrSystem.Controllers
{
    public class StageController : Controller
    {
        

        public IActionResult Index()

        {

            
            return View(null);

        }

        public IActionResult Jquery()
        {
            
            return View(null);

        }
    }
}
