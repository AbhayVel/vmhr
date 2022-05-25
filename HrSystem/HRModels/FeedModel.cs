using HREntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HRModels
{
    public class FeedModel : BaseModel
    {

        public string IdSearch { get; set; }
        public string TextDataSearch { get; set; }
        //public List<Feed> Where(List<Feed> feed)
        //{
        //    if (!string.IsNullOrWhiteSpace(IdSearch))
        //    {
        //        feed = feed.Where(x => x.Id.ToString() == IdSearch).ToList();
        //    }
        //    if (!string.IsNullOrWhiteSpace(TextDataSearch))
        //    {
        //        feed = feed.Where(x => x.TextData.Contains(TextDataSearch)).ToList();
        //    }
        //    return feed;
        //}

        public IQueryable<Feed> Where(IQueryable<Feed> feeds)
        {
            // string whereCondition = string.Empty;
            if (!string.IsNullOrWhiteSpace(TextDataSearch))
            {

                feeds = feeds.Where(x => x.TextData.Contains(TextDataSearch));

                //whereCondition = whereCondition + $"AND TypeText like '%{TypeTextSearch.Replace("'", "''")}%'";
            }

            if (!string.IsNullOrWhiteSpace(IdSearch))
            {
                int id = 0;
                if (int.TryParse(IdSearch, out id))
                {
                    feeds = feeds.Where(x => x.Id == id);
                }
            }

            return feeds;
        }

        public string Sort()
        {
            throw new NotImplementedException();
        }

        public string Where()
        {
            string whereCondition = string.Empty;
            if (!string.IsNullOrWhiteSpace(TextDataSearch))
            {
                whereCondition = whereCondition + $"AND TextData like '%{TextDataSearch.Replace("'", "''")}%'";
            }

            if (!string.IsNullOrWhiteSpace(IdSearch))
            {
                int id = 0;
                if (int.TryParse(IdSearch, out id))
                {
                    whereCondition = whereCondition + $"AND Id = {id}";
                }
            }

            return whereCondition;

        }

        public List<Feed> Sort(List<Feed> feed)
        {
            if ("asc".Equals(OrderBy, System.StringComparison.OrdinalIgnoreCase))
            {
                if ("Id".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderBy(x => x.Id).ToList();
                }
                else if ("TextData".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderBy(x => x.TextData).ToList();
                }
                else if ("Heading".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderBy(x => x.Heading).ToList();
                }
                else if ("ShortNotes".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderBy(x => x.ShortNotes).ToList();
                }
                else if ("Link".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderBy(x => x.Link).ToList();
                }
                else if ("UserName".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderBy(x => x.UserName).ToList();
                }

            }
            else

            {
                if ("Id".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderByDescending(x => x.Id).ToList();
                }
                else if ("TextData".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderByDescending(x => x.TextData).ToList();
                }
                else if ("Heading".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderByDescending(x => x.Heading).ToList();
                }
                else if ("ShortNotes".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderByDescending(x => x.ShortNotes).ToList();
                }
                else if ("Link".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderByDescending(x => x.Link).ToList();
                }
                else if ("UserName".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderByDescending(x => x.UserName).ToList();
                }


            }
            return feed;
        }
        public IQueryable<Feed> Sort(IQueryable<Feed> feed)
        {
           // string orderByString = " Order By ";
           
            if ("asc".Equals(OrderBy, System.StringComparison.OrdinalIgnoreCase))
            {
                if ("id".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderBy(x => x.Id);
                }
                else if ("TypeText".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderBy(x => x.TextData);
                }
            }
            else
            {
                if ("id".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderByDescending(x => x.Id);
                }
                else if ("TypeText".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feed = feed.OrderByDescending(x => x.TextData);
                }
            }

            return feed;
        }
        public List<Feed> Where(List<Feed> feeds)
        {
            if (!string.IsNullOrWhiteSpace(IdSearch))
            {
                feeds = feeds.Where(x => x.Id.ToString() == IdSearch).ToList();
            }
            if (!string.IsNullOrWhiteSpace(TextDataSearch))
            {
                feeds = feeds.Where(x => x.TextData.Contains(TextDataSearch)).ToList();
            }


            return feeds;
        }
        public List<Feed> sort(List<Feed> feeds)
        {
            if ("asc".Equals(OrderBy, System.StringComparison.OrdinalIgnoreCase))
            {
                if ("id".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feeds = feeds.OrderBy(x => x.Id).ToList();
                }
                else if ("TextData".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feeds = feeds.OrderBy(x => x.TextData).ToList();
                }


            }
            else
            {
                if ("id".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feeds = feeds.OrderByDescending(x => x.Id).ToList();
                }
                else if ("TextData".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feeds = feeds.OrderByDescending(x => x.TextData).ToList();
                }
            }

            return feeds;
        }
    }

}
