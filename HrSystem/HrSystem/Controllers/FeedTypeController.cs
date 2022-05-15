using HREntity;
using HRModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HrSystem.Controllers
{
    public class FeedTypeController : Controller
    {

        public IActionResult Index3()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }


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
            List<FeedType> feedTypes= GetFeedType();
            feedTypes = feedTypeModel.Where(feedTypes);
            feedTypes = feedTypeModel.Sort(feedTypes);
            feedTypeModel.PageModel.SetValues(feedTypes);
            feedTypes= feedTypes.Skip(feedTypeModel.PageModel.StartIndex).Take(feedTypeModel.PageModel.RowPerPage).ToList();
            ViewBag.Model = feedTypeModel;
            return View(feedTypes);
        }


    }
}
