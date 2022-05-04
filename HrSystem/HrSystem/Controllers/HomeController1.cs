using Microsoft.AspNetCore.Mvc;

namespace HrSystem.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
