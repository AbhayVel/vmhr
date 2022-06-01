using Microsoft.AspNetCore.Mvc.Filters;

namespace DummyMVC.filters
{
    public class MyActionFIlter : Attribute, IActionFilter
    {
        public string Name { get; set; }
        DateTime StartDate;
        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.Headers.Add("TimeTaken" +Name, (DateTime.Now - StartDate).Ticks.ToString());
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            StartDate=DateTime.Now;
        }
    }
}
