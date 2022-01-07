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
    public class Vacancy : Controller
    {
        VacancyService VacancyService = new VacancyService();

        public IActionResult Index(VacancyModel vacancyModel,PageModel pageModel)
       
        {
            
            pageModel.RowPerPage = 4 ;
            var lstVacancy = VacancyService.GetAll(vacancyModel,pageModel);
              ViewBag.orderBy = vacancyModel.OrderBy;
            ViewBag.vacancyModel = vacancyModel;
            ViewBag.columnName = vacancyModel.ColumnName; 
            ViewBag.pageModel = pageModel;

            return View(lstVacancy);

        }

      public IActionResult Add()
      {
         var vacancy = new HREntity.Vacancy();
         return View(vacancy);
      }
      [HttpPost]
      public IActionResult Save(HREntity.Vacancy vacancy)
      {

         
         
            return View("Add", vacancy);
         


        
      }
      public IActionResult Jquery(VacancyModel vacancyModel)
        {
            var lstVacancy = VacancyService.GetAll(vacancyModel,null);
             
            return View(lstVacancy);
        
        }
    }
}
