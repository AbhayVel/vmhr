using HRService;
using HrSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using HREntity;
using HRModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PageModel = HRModels.PageModel;
using System.Threading.Tasks;

namespace HrSystem.Controllers
{
    public class StageController : Controller
    {
        

        public IActionResult Index()

        {
         
         return  View();

        }

        public IActionResult Jquery()
        {
            
            return View(null);

        }
    }
}
