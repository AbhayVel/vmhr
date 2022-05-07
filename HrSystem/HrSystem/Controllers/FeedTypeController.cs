using HREntity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            public IActionResult Index()
        {
            List<FeedType> feedTypes = new List<FeedType>();

            feedTypes.Add(new FeedType
            {
                Id=1,
                TypeText = "Video"
            });

            feedTypes.Add(new FeedType
            {
                Id=2,
                TypeText = "Image"
            });

            feedTypes.Add(new FeedType
            {
                Id=3,
                TypeText = "Audio"
            });

            feedTypes.Add(new FeedType
            {
                Id =4,
                TypeText = "Text"
            });
            return View(feedTypes);
        }


    }
}
