using HREntity;
using HRModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HrSystem.Controllers
{
    public class TimeSheetController : Controller
    {

        public List<TimeSheet> GetTimeSheet()
        {
            List<TimeSheet> timeSheet = new List<TimeSheet>();

            timeSheet.Add(new TimeSheet
            {
                Id = 1,
                TextData = "Working on .Net script",
                ShortNotes = "FirstCol",
                TimeSpend = 2
            });

            timeSheet.Add(new TimeSheet
            {
                Id = 2,
                TextData = "All task completed",
                ShortNotes = "SecondCol",
                TimeSpend = 3
            });

            timeSheet.Add(new TimeSheet
            {
                Id = 3,
                TextData = "Making presentation for usecase1",
                ShortNotes = "ThirdCol",
                TimeSpend = 2
            });

            timeSheet.Add(new TimeSheet
            {
                Id = 4,
                TextData = "Making presentation for usecase2",
                ShortNotes = "FourthCol",
                TimeSpend = 3
            });

            return timeSheet;
        }
        public IActionResult Index(TimeSheetModel timeSheetModel)
        {

            List < TimeSheet > timeSheets = GetTimeSheet();

            timeSheets = timeSheetModel.Where(timeSheets);

            timeSheets = timeSheetModel.Sort(timeSheets);

            ViewBag.Model = timeSheetModel;

            return View(timeSheets);
        }
    }
}
