using DummyMVC.utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DummyMVC.filters
{
    public class MyAuthFIlter : Attribute, IAuthorizationFilter
    {
        public string Role { get; set; }
        public string Claim { get; set; }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
          if(!context.HttpContext.User.IsRole(Role, Claim))
            {
                context.Result = new RedirectResult("/home/unauth");
            }
        }
    }
}
