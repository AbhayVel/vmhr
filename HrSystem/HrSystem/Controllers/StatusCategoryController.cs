using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrSystem.Controllers
{
    public class StatusCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
