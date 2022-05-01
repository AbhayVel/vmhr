using Microsoft.AspNetCore.Mvc;

namespace DummyMVC.Controllers
{
    public class OtherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetData()
        {
            return View();
        }
    }
}
