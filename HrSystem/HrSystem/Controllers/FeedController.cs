using HREntity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HrSystem.Controllers
{
    public class FeedController : Controller
    {
        public IActionResult Index()
        {
            List<Feed> feed = new List<Feed>();

            feed.Add(new Feed
            {
                Id = 1,
                TextData = "Heading"
            });

            feed.Add(new Feed
            {
                Id = 2,
                TextData = "ShortNotes"
            });

            feed.Add(new Feed
            {
                Id = 3,
                TextData = "FeedTypeId"
            });

            feed.Add(new Feed
            {
                Id = 4,
                TextData = "Link"
            });
            feed.Add(new Feed
            {
                Id = 5,
                TextData = "UserName"
            });
            feed.Add(new Feed
            {
                Id = 6,
                TextData = "FeedDate"
            });
            return View(feed);
        }
    }
}
