using DummyMVC.Models;
using DummyMVC.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Security.Principal;

namespace DummyMVC.Controllers
{

    public class Dirty
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class User2 : IIdentity
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string? AuthenticationType { get; set; }

        public bool IsAuthenticated { get; set; }

        public string? Name { get; set; }
    }

    public class XYZ
    {
        [My3CharValidation(ErrorMessage ="Please enter at least 3 char.")]
        public string UserName { get; set; }

        [UIHint("pass")]
        [Required]
        public string Password { get; set; }
    }
    public class LoginController : Controller
    {
        ScopedClass ScopedClass;
        SingoltoneClassExample SingoltoneClassExample;
        TransientClass TransientClass;
        LoginService LoginService;
        public LoginController(ScopedClass ScopedClass, SingoltoneClassExample SingoltoneClassExample, TransientClass TransientClass, LoginService LoginService)
        {
            this.LoginService =LoginService;
            this.ScopedClass = ScopedClass;
            this.SingoltoneClassExample = SingoltoneClassExample;
            this.TransientClass = TransientClass;
            this.ScopedClass.Count++;
            this.SingoltoneClassExample.Count++;
            this.TransientClass.Count++;
        }
        public IActionResult Index(string ReturnUrl)
        {
            ViewBag.ReturnUrl= ReturnUrl;
            XYZ xYZ = new XYZ();
            xYZ.UserName = "AAA";
            return View(xYZ);
        }
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Login/Index");
         }
            public async Task<ActionResult> Save(string userName, string password, string ReturnUrl, XYZ xyz, Dirty dirty)
        {
            if (ModelState.IsValid)
            {

            }
            if("abhay".Equals(userName) && password == "abc")
            {
                User2 user2 = new User2();
                user2.UserName = userName; ;
                user2.AuthenticationType = "cookies";
                user2.IsAuthenticated = true;
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(user2);
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role,"Admin"));
                claimsIdentity.AddClaim(new Claim("CanSeeFeeds","Yes"));
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

               await HttpContext.SignInAsync("cookies", claimsPrincipal);
                HttpContext.User = claimsPrincipal;
                if (string.IsNullOrEmpty(ReturnUrl))
                {
                    return Redirect("/Home/Index");
                }
                else
                {
                    return Redirect(ReturnUrl);
                }
                
            }


            if ("ketaki".Equals(userName) && password == "abc")
            {
                User2 user2 = new User2();
                user2.UserName = userName; ;
                user2.AuthenticationType = "cookies";
                user2.IsAuthenticated = true;
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(user2);
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "Sales"));
                claimsIdentity.AddClaim(new Claim("CanSeeFeeds", "No"));
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync("cookies", claimsPrincipal);
                HttpContext.User = claimsPrincipal;
                if (string.IsNullOrEmpty(ReturnUrl))
                {
                    return Redirect("/Home/Index");
                }
                else
                {
                    return Redirect(ReturnUrl);
                }

            }

            return View("Index", xyz);
        }
    }
}
