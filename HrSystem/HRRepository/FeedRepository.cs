using HRDB;
using HREntity;
using HRModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRRepository
{
    public class FeedRepository : IFeedRepository
    {
        private string _query = "Select Id,TextData from Feed Where  1=1";

        private string _queryCount = "Select Count(1) as count from Feed Where  1=1";
        public HrSystemDBContext HrSystemDBContext { get; set; } //Instance variable 

        public FeedRepository()
        {
            HrSystemDBContext = new HrSystemDBContext();
        }

        

        public List<Feed> GetAll(FeedModel feedModel)
        {
            IQueryable<Feed> feed = HrSystemDBContext.Feeds;
            feed = feedModel.Where(feed);
            var count = feed.Count();
            feed = feedModel.Sort(feed);
            feed = feedModel.PageModel.SetValues(feed, count);
            var result = feed.ToList();
            return result;
        }

        public List<Feed> GetAllQuery(FeedModel feedModel)
        {
            var countQuery = _queryCount + feedModel.Where();
            var count = HrSystemDBContext.CountValue(countQuery);
            var query = _query + feedModel.Where() + feedModel.Sort() + feedModel.PageModel.SetValues(count);
            var result = HrSystemDBContext.Feeds.FromSqlRaw(query).ToList();
            return result;
        }
        public Feed Get(int id)
        {
            var result = HrSystemDBContext.Feeds.FirstOrDefault(x => x.Id == id);
            return result;
        }


        public bool Delete(int id)
        {
            var result = HrSystemDBContext.Feeds.FirstOrDefault(x => x.Id == id);

            if (result != null)
            {
                HrSystemDBContext.Feeds.Remove(result);

                HrSystemDBContext.SaveChanges();
                return true;
            }
            return false;
        }
        public Feed Save(Feed feed)
        {



            if (!feed.Id.HasValue || feed.Id.Value == 0)
            {
                feed.Id = null;
                HrSystemDBContext.Feeds.Add(feed);
            }
            else
            {
                var result = HrSystemDBContext.Feeds.FirstOrDefault(x => x.Id == feed.Id);
                if (result != null)
                {
                    result.TextData = feed.TextData;
                    
                }
                else
                {
                    throw new Exception("Requested object doesnot exists");
                }

            }
            HrSystemDBContext.SaveChanges();

            return feed;
        }

    }
}