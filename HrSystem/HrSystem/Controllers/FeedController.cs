using HREntity;
using HRModels;
using HRRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HrSystem.Controllers
{
    public class FeedController : Controller
    {
        public List<Feed> GetFeed() {
            List<Feed> feed = new List<Feed>();

            feed.Add(new Feed
            {
                Id = 1,
                TextData = "Python Learning ",
                Heading = "Python",
                ShortNotes = "Python Learning Session",
                FeedTypeId = 1,
                Link = "#",
                UserName = "Aditi"

            });

            feed.Add(new Feed
            {
                Id = 2,
                TextData = "C# Learning ",
                Heading = "C-sharp ",
                ShortNotes = "Tutorial On C-Sharp",
                FeedTypeId = 2,
                Link = "#",
                UserName = "Avi"

            });

            feed.Add(new Feed
            {
                Id = 3,
                TextData = "UI Design",
                Heading = "Web Design",
                ShortNotes = "Learn Website design",
                FeedTypeId = 3,
                Link = "#",
                UserName = "Anvi"

            });
            feed.Add(new Feed
            {
                Id = 4,
                TextData = ".Net Learning",
                Heading = "Dot Net",
                ShortNotes = "ASP .Net Learning Session",
                FeedTypeId = 4,
                Link = "#",
                UserName = "ketaki"

            });
            return feed;
        }
       
        public IActionResult Index( FeedModel feedModel)
        {
            List<Feed> feed = _feedRepository.GetAll(feedModel);
            ViewBag.Model = feedModel;

            //feed = feedModel.Where(feed);
            //feed = feedModel.Sort(feed);
            //feedModel.PageModel.SetValues(feed);
            //feed = feed.Skip(feedModel.PageModel.StartIndex).Take(feedModel.PageModel.RowPerPage).ToList();
            
            return View(feed);
        }
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return View(new Feed());
            }
            var result = _feedRepository.Get(id);
            if (result == null)
            {
                return View(new Feed());
            }
            return View(result);
        }

        public IActionResult Delete(int id)
        {
            var result = _feedRepository.Delete(id);
            return new RedirectResult("~/feed/index");
        }


        [ValidateAntiForgeryToken]
        public IActionResult Save(Feed feed)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", feed);
            }
            var result = _feedRepository.Save(feed);
            return new RedirectResult("~/feed/index");
        }


    }
}
