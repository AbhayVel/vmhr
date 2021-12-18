using HrSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HrSystem.Controllers
{
   public class UsersController : Controller
   {
      public IActionResult Index(string columnName, string orderBy)
      {
         List<Users> lstUser = new List<Users>();
         lstUser.Add(new Users
         {
            UserId = 1,
            Name = "Abhi",
            UserName = "Admin",
            Action="Active"
         });
         lstUser.Add(new Users
         {
            UserId = 2,
            Name = "Nikita",
            UserName = "Admin2",
            Action = "Active"

         });
         lstUser.Add(new Users
         {
            UserId = 4,
            Name = "Suraj",
            UserName = "Admin4",
            Action = "Active"

         });
         lstUser.Add(new Users
         {
            UserId = 3,
            Name = "Aniket",
            UserName = "Admin3",
            Action = "Active"

         });
         
         if ("id".Equals(columnName))
         {
            if (orderBy.Equals("asc"))
            {
               lstUser = lstUser.OrderBy(X => X.UserId).ToList();
            }
            else
            {
               lstUser = lstUser.OrderByDescending(X => X.UserId).ToList();
            }
         }
         if ("name".Equals(columnName))
         {
            if (orderBy.Equals("asc"))
            {
               lstUser = lstUser.OrderBy(X => X.Name).ToList();
            }
            else
            {
               lstUser = lstUser.OrderByDescending(X => X.Name).ToList();
            }
         }
         if("asc".Equals(orderBy))
         {
            orderBy = "desc";
         }else
         {
            orderBy = "asc";
         }
         ViewBag.OrderBy = orderBy;

         return View(lstUser);
      }
   }
}
