using HREntity;
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
        public IActionResult Index( string orderBy, string orderType, string IdSearch, string TextDataSearch)
        {
            List<Feed> feed = GetFeed();
            if (!string.IsNullOrWhiteSpace(IdSearch))
            {
                feed = feed.Where(x => x.Id.ToString() == IdSearch).ToList();
            }
            if (!string.IsNullOrWhiteSpace(TextDataSearch))
            {
                feed = feed.Where(x => x.TextData.Contains(TextDataSearch)).ToList();
            }
            if ("asc".Equals(orderBy, System.StringComparison.OrdinalIgnoreCase))
            {
                if ("Id".Equals(orderBy, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderBy(x => x.Id).ToList();
                }
                else if ("TextData".Equals(orderBy, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderBy(x => x.TextData).ToList();
                }
                else if ("Heading".Equals(orderBy, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderBy(x => x.Heading).ToList();
                }
                else if ("ShortNotes".Equals(orderBy, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderBy(x => x.ShortNotes).ToList();
                }
                else if ("Link".Equals(orderBy, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderBy(x => x.Link).ToList();
                }
                else if ("UserName".Equals(orderBy, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderBy(x => x.UserName).ToList();
                }
                orderType = "desc";
            }
            else
            {
                if ("Id".Equals(orderBy, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderByDescending(x => x.Id).ToList();
                }
                else if ("TextData".Equals(orderBy, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderByDescending(x => x.TextData).ToList();
                }
                else if ("Heading".Equals(orderBy, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderByDescending(x => x.Heading).ToList();
                }
                else if ("ShortNotes".Equals(orderBy, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderByDescending(x => x.ShortNotes).ToList();
                }
                else if ("Link".Equals(orderBy, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderByDescending(x => x.Link).ToList();
                }
                else if ("UserName".Equals(orderBy, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderByDescending(x => x.UserName).ToList();
                }
                orderType = "asc";
            }
            ViewBag.OrderType = orderType;
            return View(feed);
        }
    }
}
