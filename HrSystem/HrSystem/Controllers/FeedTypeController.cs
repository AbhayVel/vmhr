using HREntity;
using HRModels;
using HRRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HrSystem.Controllers
{
    public class FeedTypeController : Controller
    {
        private string _myTemp;

        public string MyTemp {
            get {
                _myTemp = HttpContext.Session.GetString("myTemp");
                HttpContext.Session.Remove("myTemp");
                return _myTemp;
            }

            set {
                HttpContext.Session.SetString("myTemp", value);
                _myTemp = value;
            
            }

            }
        IFeedTypeRepository _feedTypeRepository;

        public FeedTypeController(IFeedTypeRepository feedTypeRepository)
        {
            _feedTypeRepository = feedTypeRepository;
        }

        public IActionResult Index3()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }

        //SOLID 

        public List<FeedType> GetFeedType()
        {
            List<FeedType> feedTypes = new List<FeedType>();

            feedTypes.Add(new FeedType
            {
                Id = 1,
                TypeText = "Video"
            });

            feedTypes.Add(new FeedType
            {
                Id = 2,
                TypeText = "Image"
            });

            feedTypes.Add(new FeedType
            {
                Id = 3,
                TypeText = "Audio"
            });

            feedTypes.Add(new FeedType
            {
                Id = 4,
                TypeText = "Text"
            });

            return feedTypes;
        }

        //public IActionResult Index(string orderBy, string orderType, string IdSearch, string TypeTextSearch)
        public IActionResult Index(FeedTypeModel feedTypeModel)
        {
            var data = MyTemp;
           
            ViewData["show"] = "I am show";
            ViewBag.Data = new Dictionary<string, string>();
            ViewBag.Data.Add("show", "I am viewBag SHow");
            List<FeedType> feedTypes = _feedTypeRepository.GetAll(feedTypeModel);
            ViewBag.Model = feedTypeModel;

            return View(feedTypes);
        }


        public IActionResult Edit(int id)
        {
            if(id == 0)
            {
                return View(new FeedType());
            }
            var result = _feedTypeRepository.Get(id);
            if(result == null)
            {
                return View(new FeedType());
            }
            return View(result);
        }

        public IActionResult Delete(int id)
        {
            var result = _feedTypeRepository.Delete(id);
            return new RedirectResult("~/feedType/index");
        }


        [ValidateAntiForgeryToken]
        public IActionResult Save(FeedType feedType)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", feedType);
            }
            MyTemp = "ABhay";
            TempData["FeedTypeSaveT"] = "yes";

            ViewData["FeedTypeSaveV"] = "yes";
            var result = _feedTypeRepository.Save(feedType);
            return new RedirectResult("~/feedType/index");
        }

    }
}
