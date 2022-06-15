using HREntity;
using HRModels;
using HRRepository;
using HRService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrSystem.Controllers
{
    [Authorize]
    public class TimeSheetController : Controller
    {

       
        TimeSheetRepository _timeSheetRepository;
        IUserService _userService;

        public TimeSheetController(TimeSheetRepository timeSheetRepository, IUserService UserService)
        {
            _timeSheetRepository = timeSheetRepository;
            _userService = UserService;
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

        [Route("{controller}")]
        [Route("{controller}/Json")]
        [Route("TimeSheet/onlyTable")]
        [Route("TimeSheet/Index")]
        public async Task<IActionResult> Index()
        {

            TimeSheetModel timeSheetModel = new TimeSheetModel();

          
            bool isPost=false;
           // timeSheetModel.UserNameSearch = "c";
            var output = TryValidateModel(timeSheetModel);
            if (Request.Method.Equals("POST", System.StringComparison.OrdinalIgnoreCase))
            {
                isPost=true;
                 await TryUpdateModelAsync(timeSheetModel);
               
            }

            if (string.IsNullOrEmpty(timeSheetModel.UserName))
            {
                var claim = User.Claims.FirstOrDefault(x => x.Type == "UserName");

                timeSheetModel.UserName = claim.Value;
            }
            List<TimeSheet> timeSheets = _timeSheetRepository.GetAll(timeSheetModel);

            //timeSheets = timeSheetModel.Where(timeSheets);

            //timeSheets = timeSheetModel.Sort(timeSheets);

            //timeSheetModel.PageModel.SetValues(timeSheets);

            //timeSheets = timeSheets.Skip(timeSheetModel.PageModel.StartIndex).Take(timeSheetModel.PageModel.RowPerPage).ToList();

            ViewBag.Model = timeSheetModel;
            if (isPost)
            {
                return PartialView("ajax",timeSheets);
            }

            if (Request.Path.Value.Contains("Json"))
            {
                return Json(timeSheets);
            }
            if (Request.Path.Value.Contains("onlyTable"))
            {
                return View("table", timeSheets);
            }
            return View(timeSheets);
        }

       
        public IActionResult Edit(int id)
        {
           

            if (id == 0)
            {
            }

            var result = _timeSheetRepository.Get(id);
            if (result == null)
            {
                return View(new TimeSheet());
            }
        
            return View(result);
        }

        public IActionResult Delete(int id)
        {
            var result = _timeSheetRepository.Delete(id);
            return new RedirectResult("~/timeSheet/index");
        }


        [ValidateAntiForgeryToken]
        public IActionResult Save(TimeSheet timeSheet)
        {
            if (!ModelState.IsValid)
            {
                
                return View("Edit", timeSheet);
            }
            var result = _timeSheetRepository.Save(timeSheet);
            return new RedirectResult("~/timeSheet/index");
        }
    }
}
