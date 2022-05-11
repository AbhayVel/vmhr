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

            

            if (!string.IsNullOrWhiteSpace(timeSheetModel.IdSearch))
            {
                timeSheets = timeSheets.Where(x => x.Id.ToString() == timeSheetModel.IdSearch).ToList();
            }
            if (!string.IsNullOrWhiteSpace(timeSheetModel.TextDataSearch))
            {
                timeSheets = timeSheets.Where(x => x.TextData.Contains(timeSheetModel.TextDataSearch)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(timeSheetModel.ShortNotesSearch))
            {
                timeSheets = timeSheets.Where(x => x.ShortNotes == timeSheetModel.ShortNotesSearch).ToList();
            }
            if (!string.IsNullOrWhiteSpace(timeSheetModel.TimeSpendSearch))
            {
                timeSheets = timeSheets.Where(x => x.TimeSpend.ToString() == timeSheetModel.TimeSpendSearch).ToList();
            }

            if ("asc".Equals(timeSheetModel.OrderType, System.StringComparison.OrdinalIgnoreCase))
            {
                if ("id".Equals(timeSheetModel.OrderBy, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderBy(x => x.Id).ToList();
                }
                else if ("TextData".Equals(timeSheetModel.OrderBy, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderBy(x => x.TextData).ToList();
                }

                timeSheetModel.OrderType = "desc";
            }
            else
            {
                if ("id".Equals(timeSheetModel.OrderBy, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderByDescending(x => x.Id).ToList();
                }
                else if ("TextData".Equals(timeSheetModel.OrderBy, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderByDescending(x => x.TextData).ToList();
                }

                timeSheetModel.OrderType = "asc";
            }

            ViewBag.Model = timeSheetModel;

            return View(timeSheets);
        }
    }
}
