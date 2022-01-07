using Microsoft.AspNetCore.Mvc;

namespace HrSystem.Controllers
{
   public class LogIn : Controller
   {
      public IActionResult Index()
      {
         return View();
      }
      public IActionResult Add()
      {
         var login = new HREntity.Login();
         return View(login);
      }
      [HttpPost]
      public IActionResult Save(HREntity.Login login)
      {



         return View("Add", login);




      }
   }
}
