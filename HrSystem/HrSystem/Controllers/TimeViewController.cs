using HREntity;
using HRModels;
using HRRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HrSystem.Controllers
{
    public class TimeViewController : Controller
    {
        public TimeSheetRepository TimeSheetRepository { get; set; }
        public TimeViewController(TimeSheetRepository _timeSheetRepository)
        {
            TimeSheetRepository=_timeSheetRepository;
        }
        public IActionResult Index(TimeSheetModel timeSheetModel)
        {
            timeSheetModel.PageModel.RowPerPage = int.MaxValue;
          List<TimeSheet> timeSheets=  TimeSheetRepository.GetAll(timeSheetModel);
            return View(timeSheets);
        }
    }
}
