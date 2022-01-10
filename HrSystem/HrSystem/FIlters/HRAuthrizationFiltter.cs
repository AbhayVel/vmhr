using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
 

namespace HrSystem.FIlters
{
    public class HRAuthrizationFiltter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string controllerName = context.RouteData.Values["Controller"].ToString();
            string actionName = context.RouteData.Values["Action"].ToString();
            string path = context.HttpContext.Request.Path.ToString();

            if(controllerName== "Users" && actionName== "Login")
            {
                return;
            } else
            {
                var userId = context.HttpContext.Session.GetString("userName");
                if (userId == null)
                {
                    context.Result =new RedirectResult("/Users/Login");
                }
            }
        }
    }
}
