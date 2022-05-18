using Microsoft.AspNetCore.Mvc;

namespace HrSystem.Controllers
{
    public class LearningController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
