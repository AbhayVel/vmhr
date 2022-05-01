using DummyMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DummyMVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            var users = GetUsers();
            return View(users);
        }


        List<User> GetUsers()
        {
            List<User> lstUser= new List<User>();

            lstUser.Add(new User { Id=1, FName = "Ketaki", Email ="Ketaki@vm3.com", Age = 23, Message="Na", Pnum="8989898" });
            lstUser.Add(new User { Id = 2, FName = "Manthan", Email = "Manthan@vm3.com", Age = 21, Message = "Na", Pnum = "8989898" });
            lstUser.Add(new User {Id=3, FName = "Abhijeet", Email = "Abhijeet@vm3.com", Age = 24, Message = "Na", Pnum = "8989898" });

            return lstUser;
        }
    }
}
