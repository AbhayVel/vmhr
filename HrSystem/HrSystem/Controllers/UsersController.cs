using HREntity;
using HRModels;
using HRService;
using HrSystem.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrSystem.Controllers
{
   public class UsersController : Controller
   {
      IUserService UserService { get; set; }

      public UsersController(IUserService userService)
      {
         UserService = userService;
      }

        [HttpGet]
      public IActionResult Login()
      {
         return View();
      }


        [HttpGet]
        public async Task<IActionResult> LogOutAsync()
        {
            await HttpContext.SignOutAsync();
            return View("Login");
        }


        [HttpPost]
        public async Task<IActionResult> LoginAsync(User user)
        {

          var userLogin=  UserService.Get(user.UserName, user.Password);
            if(userLogin != null)
            {
                try
                {
                    await HttpContext.SignInAsync("cookies", userLogin);
                }
                catch (Exception ex)
                {

                }
              
                HttpContext.User = userLogin;
                return Redirect("/Applications/Index");
            }
            else
            {
                ViewBag.Message = "UserName/Password is in valid.";
                return View();
            }
            //if (user.UserName.Equals("abhay")  && user.Password.Equals("abc"))
            //{
            //    HttpContext.Session.SetString("userName", user.UserName);
            //    return Redirect("/Applications/Index");
            //} else
            //{
            //    ViewBag.Message = "UserName/Password is in valid.";
            //    return View();
            //}

        }
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

         return View("Index",lstUser);
      }

      public IActionResult Delete(int id)
      {
         var user = UserService.Get(id);
         if (user == null)
         {
            return Redirect("/users/index");
         }


         UserService.Delete(id);
         return Redirect("/applications/index");
      }

      public IActionResult Edit(int id)
      {
         var user = UserService.Get(id);

         if (user == null)
         {
            user = new User();
         }

         return View("Add", user);
      }
      public IActionResult Add()
      {
         var user = new User();
         return View(user);
      }
      [HttpPost]
      public IActionResult Save(User user)
      {


         if (!ModelState.IsValid)
         {
            return View("Add", user);
         }

         UserService.Save(user);
         //Save 
         return Redirect("/Users/index");

      }


   }

}