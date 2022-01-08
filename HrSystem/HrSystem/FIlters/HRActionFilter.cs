using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrSystem.FIlters
{
    public class HRActionFilter : Attribute, IActionFilter
    {
        private readonly Logger _logger;

        DateTime StartTime;

       public HRActionFilter()
        {
            _logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        }


        public void OnActionExecuted(ActionExecutedContext context)
        {
            //_logger.Trace("I am logging Trace");
            //_logger.Debug("I am logging Debug");
            //_logger.Info("I am logging Info");
            //_logger.Warn("I am logging warn");
            //_logger.Error("I am logging Error");
            //_logger.Fatal("I am logging Fatal");
            DateTime endTime = DateTime.Now;

           var path= context.HttpContext.Request.Path.ToString();
            _logger.Info($"{path} has taken ${(endTime - StartTime).TotalMilliseconds}");

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            StartTime = DateTime.Now;
            //string user = context.HttpContext.Session.GetString("userName");

        }
    }
}
