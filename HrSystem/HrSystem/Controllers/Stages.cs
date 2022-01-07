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
    public class Stages : Controller
    {
        

        public IActionResult Index()

        {

            
            return View(null);

        }
      public IActionResult Add()
      {
         var stage = new Stage();
         return View(stage);
      }
      [HttpPost]
      public IActionResult Save(Stage stage)
      {



         return View("Add", stage);




      }
   }
}
