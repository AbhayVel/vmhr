using DummyMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DummyMVC.Controllers
{

    /// <summary>
    /// Home/index
    /// </summary>
    /// 
    //Name +"Controller"
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Features()
        {
            return View();
        }

        public IActionResult Design()
        {
            return View();
        }

        public IActionResult Price()
        {
            return View();
        }

        public IActionResult About()
        {
            User user= new User();

            return View(user);
        }



        // public IActionResult Save(string fname, string email, string pnum, int age, string message)
        public IActionResult Save(User user)
        {

            user.FName = user.FName.ToUpper();
          //  var fname = Request.Query.FirstOrDefault(x => x.Key.ToLower() == "fname").Value;
            return View("about", user);
        }

        public IActionResult GetData()
        {
            return View();
        }

        public IActionResult GetData2()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}