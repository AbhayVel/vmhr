using Microsoft.AspNetCore.Mvc;

namespace HrSystem.Controllers
{
   public class UsersController : Controller
   {
      public IActionResult Index()
      {
         return View();
      }
   }
}
