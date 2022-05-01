using Microsoft.AspNetCore.Mvc;

namespace UIproject.Controllers
{
    public class other : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult dummy1()
        {
            return View();
        }
    }
}
