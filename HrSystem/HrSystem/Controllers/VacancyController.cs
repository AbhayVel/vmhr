﻿using HRService;
using HrSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using HREntity;
using HRModels;
using HrSystem.FIlters;
using Microsoft.AspNetCore.Authorization;

namespace HrSystem.Controllers
{

    [HRExceptionFilter]
    [Authorize]
    public class VacancyController : Controller
    {
    
        VacancyService VacancyService { get; set; }

        public VacancyController(VacancyService vacancyService)
        {
            VacancyService = vacancyService;
        }

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
            var vacancy = new Vacancy();
            return View(vacancy);

        }

        public IActionResult Delete(int id)
        {
            var vacancy = VacancyService.Get(id);
            if (vacancy == null)
            {
                return Redirect("/vacancy/index");
            }
            VacancyService.Delete(id);
            return Redirect("/vacancy/index");
        }



         public IActionResult Edit(int id)
        {
            var vacancy = VacancyService.Get(id);
            if (vacancy == null)
            {
                vacancy = new Vacancy();
            }
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

        }
        public IActionResult Jquery(VacancyModel vacancyModel)
        {
            var lstVacancy = VacancyService.GetAll(vacancyModel,null);
             
            return View(lstVacancy);
        
        }
    }
}
