using HRService;
using HrSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using HREntity;
using HRModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HrSystem.Controllers
{
    public class VacancyController : Controller
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

            return View("Index",lstVacancy);

        }

        public IActionResult Add()
        {
            var vacancy = new Vacancy();
             return View(vacancy);

        }

        public IActionResult Edit(int id)
        {
            var vacancy = VacancyService.Get(id);
            if (vacancy == null)
            {
                vacancy = new Vacancy();            
            }
            var vacancyList = VacancyService.GetWithSelect();
            return View("add",vacancy);

        }
        [HttpPost]
        public IActionResult Save(Vacancy vacancy)
        { 
            if (!ModelState.IsValid)
            {
                return View("Add", vacancy);
            }
            VacancyService.Save(vacancy);
            return Redirect("/vacancy/index");

            return Index(new VacancyModel(),new PageModel());


        }
        public IActionResult Jquery(VacancyModel vacancyModel)
        {
            var lstVacancy = VacancyService.GetAll(vacancyModel,null);
             
            return View(lstVacancy);
        
        }
    }
}
