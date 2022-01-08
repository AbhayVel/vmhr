using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrSystem.FIlters
{
    public class HRExceptionFilter : ExceptionFilterAttribute
    {
        private readonly Logger _logger;

        

        public HRExceptionFilter()
        {
            _logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        }

        public override void OnException(ExceptionContext context)
        {
            string controllerName = context.RouteData.Values["Controller"].ToString();
            string actionName = context.RouteData.Values["Action"].ToString();
            string path = context.HttpContext.Request.Path.ToString();
            string message = context.Exception.Message;
            string stackTrace = context.Exception.StackTrace;

            string err = $"controllerName: {controllerName} ;actionName : {actionName};  path : {path};message : {message};stackTrace : {stackTrace};";
            _logger.Error(err);
            context.Result = new RedirectResult("Exception/Index");
        }
        public override async Task OnExceptionAsync(ExceptionContext context)
        {

            string controllerName = context.RouteData.Values["Controller"].ToString();
            string actionName = context.RouteData.Values["Action"].ToString();
            string path = context.HttpContext.Request.Path.ToString();
            string message = context.Exception.Message;
            string stackTrace = context.Exception.StackTrace;

            string err = $"controllerName: {controllerName} ;actionName : {actionName};  path : {path};message : {message};stackTrace : {stackTrace};";
            _logger.Error(err);
            context.Result = new RedirectResult("Exception/Index");
        }
    }
}
