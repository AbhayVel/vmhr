using HRModels;
using HRService;
using HrSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HrSystem.Controllers
{
   public class UsersController : Controller
   {
      UserService UserService = new UserService();
      

      public IActionResult Index(UserModel userModel, PageModel pageModel)
      {
         //PageModel pageModel = new PageModel();
         //pageModel.CurrentPage = 1;
         //pageModel.TotalRowCount = lstUser.Count;
         pageModel.RowPerPage = 4;
         var lstUser = UserService.GetAll(userModel, pageModel);

         //if ("asc".Equals(userModel.OrderBy))
         //{
         //   userModel.OrderBy = "desc";
         //}
         //else
         //{
         //   userModel.OrderBy = "asc";
         //}
         
         ViewBag.orderBy = userModel.OrderBy;
         ViewBag.columnName = userModel.ColumnName;
         ViewBag.pageModel = pageModel;
         ViewBag.userModel = userModel;

         return View(lstUser);
      }


   }

}