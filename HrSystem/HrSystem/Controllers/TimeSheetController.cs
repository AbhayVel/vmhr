using HREntity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HrSystem.Controllers
{
    public class TimeSheetController : Controller
    {
        public IActionResult Index()
        {
            List<TimeSheet> timeSheet = new List<TimeSheet>();

            timeSheet.Add(new TimeSheet
            {
                Id=1,
                TextData = "Working on .Net script"
            }) ; 

            timeSheet.Add(new TimeSheet
            {
                TextData = "All task completed"
            });

            timeSheet.Add(new TimeSheet
            {
                TextData = "Making presentation for usecase1"
            });

            timeSheet.Add(new TimeSheet
            {
                TextData = "Making presentation for usecase2"
            });

            return View(timeSheet);
        }
    }
}
