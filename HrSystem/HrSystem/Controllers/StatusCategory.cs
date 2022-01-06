using Microsoft.AspNetCore.Mvc;

namespace HrSystem.Controllers
{
   public class StatusCategory : Controller
   {
      public IActionResult Index()
      {
         return View();
      }
   }
}
