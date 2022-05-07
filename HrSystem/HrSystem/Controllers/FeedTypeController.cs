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

            if (!string.IsNullOrWhiteSpace(feedTypeModel.TypeTextSearch))
            {
                feedTypes= feedTypes.Where(x=>x.TypeText.Contains(feedTypeModel.TypeTextSearch)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(feedTypeModel.IdSearch))
            {

                feedTypes = feedTypes.Where(x => x.Id.ToString()== feedTypeModel.IdSearch).ToList();
            }

            if ("asc".Equals(feedTypeModel.OrderType, System.StringComparison.OrdinalIgnoreCase))
            {
                if ("id".Equals(feedTypeModel.OrderBy, System.StringComparison.OrdinalIgnoreCase))
                {
                    feedTypes = feedTypes.OrderBy(x => x.Id).ToList();
                }
                else if ("TypeText".Equals(feedTypeModel.OrderBy, System.StringComparison.OrdinalIgnoreCase))
                {
                    feedTypes = feedTypes.OrderBy(x => x.TypeText).ToList();
                }
                feedTypeModel.OrderType = "desc";
            } else
            {
                if ("id".Equals(feedTypeModel.OrderBy, System.StringComparison.OrdinalIgnoreCase))
                {
                    feedTypes = feedTypes.OrderByDescending(x => x.Id).ToList();
                }
                else if ("TypeText".Equals(feedTypeModel.OrderBy, System.StringComparison.OrdinalIgnoreCase))
                {
                    feedTypes = feedTypes.OrderByDescending(x => x.TypeText).ToList();
                }
                feedTypeModel.OrderType = "asc";
            }

            ViewBag.Model = feedTypeModel;

            return View(feedTypes);
        }


    }
}
