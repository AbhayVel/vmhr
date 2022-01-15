using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrSystem.FIlters
{

    public class HRRoleAuthorization : Attribute, IAuthorizationFilter
    {

        public string Roles { get; set; }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(context.HttpContext.User == null)
            {
                context.Result = new RedirectResult("/Users/Login");
            }

            var user = context.HttpContext.User;
            if (!user.IsInRoleCheck(Roles))
            {
                context.Result = new RedirectResult("/UnAuthorize/Index");
            }




        }
    }
}
