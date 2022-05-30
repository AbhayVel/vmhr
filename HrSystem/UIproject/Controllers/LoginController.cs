using Microsoft.AspNetCore.Mvc;

namespace UIproject.Controllers
{
    public class XYZ
    {
        public string UserName { get; set; }

        public string password {get; set; }
    }
    public class User2
    {
        public string UserName { get; set; }

        public string password { get; set; }
    }
    public class Dirty
    {
        public string UserName { get; set; }

        public string password { get; set; }

    }
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            var xyz = new XYZ();
            xyz.UserName = "ketaki";
            return View(xyz);
        }

        public ActionResult Save(string userName, string password, XYZ xyz, User2 user2, Dirty dirty) {
            return View("Index", xyz);
        }
    }
}
