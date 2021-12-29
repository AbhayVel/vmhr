using Microsoft.AspNetCore.Mvc;

namespace HrSystem.Controllers
{
   public class Settings : Controller
   {
      public IActionResult Index()
      {
         return View();
      }
   }
}
