using HREntity;
using HRModels;
using HRRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HrSystem.Controllers
{
    public class TimeSheetController : Controller
    {
        TimeSheetRepository _timeSheetRepository;

        public TimeSheetController(TimeSheetRepository timeSheetRepository)
        {
            _timeSheetRepository = timeSheetRepository;
        }

        public List<TimeSheet> GetTimeSheet()
        {
            

            List<TimeSheet> timeSheet = new List<TimeSheet>();

            timeSheet.Add(new TimeSheet
            {
                Id = 1,
                UserName = "Working on .Net script",
                ShortNotes = "FirstCol",
                TimeSpend = 2
            });

            timeSheet.Add(new TimeSheet
            {
                Id = 2,
                UserName = "All task completed",
                ShortNotes = "SecondCol",
                TimeSpend = 3
            });

            timeSheet.Add(new TimeSheet
            {
                Id = 3,
                UserName = "Making presentation for usecase1",
                ShortNotes = "ThirdCol",
                TimeSpend = 2
            });

            timeSheet.Add(new TimeSheet
            {
                Id = 4,
                UserName = "Making presentation for usecase2",
                ShortNotes = "FourthCol",
                TimeSpend = 3
            });

            return timeSheet;
        }
        public IActionResult Index(TimeSheetModel timeSheetModel)
        {

            List<TimeSheet> timeSheets = _timeSheetRepository.GetAll(timeSheetModel);

            //timeSheets = timeSheetModel.Where(timeSheets);

            //timeSheets = timeSheetModel.Sort(timeSheets);

            //timeSheetModel.PageModel.SetValues(timeSheets);

            //timeSheets = timeSheets.Skip(timeSheetModel.PageModel.StartIndex).Take(timeSheetModel.PageModel.RowPerPage).ToList();

            ViewBag.Model = timeSheetModel;

            return View(timeSheets);
        }
    }
}
