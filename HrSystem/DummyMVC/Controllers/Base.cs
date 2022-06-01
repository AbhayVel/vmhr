using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DummyMVC.Controllers
{
    public class Base : Controller 
    {


        public void OnResultExecuted(ResultExecutedContext context)
        {
            context.HttpContext.Response.Headers.Add("ResultTimeTaken", (DateTime.Now - StartDate).Ticks.ToString());
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            StartDate = DateTime.Now;
        }

        DateTime StartDate;
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.Headers.Add("TimeTaken", (DateTime.Now - StartDate).Ticks.ToString());
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            StartDate = DateTime.Now;
        }
    }
}
