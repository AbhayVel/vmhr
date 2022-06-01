using Microsoft.AspNetCore.Mvc.Filters;

namespace DummyMVC.filters
{
    public class MyResultActionFIlter :  IResultFilter
    {
        DateTime StartDate;

        public void OnResultExecuted(ResultExecutedContext context)
        {
            context.HttpContext.Response.Headers.Add("ResultTimeTaken", (DateTime.Now - StartDate).Ticks.ToString());
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
             StartDate = DateTime.Now;
        }
    }
}
