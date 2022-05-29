using Microsoft.AspNetCore.Mvc.Filters;

namespace DummyMVC.filters
{
    public class ExceptionFIlter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.Redirect("/Home/Error");
            context.ExceptionHandled = true;
        }
    }
}
