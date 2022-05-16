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
        public List<Feed> Where(List<Feed> feed)
        {
            if (!string.IsNullOrWhiteSpace(IdSearch))
            {
                feed = feed.Where(x => x.Id.ToString() == IdSearch).ToList();
            }
            if (!string.IsNullOrWhiteSpace(TextDataSearch))
            {
                feed = feed.Where(x => x.TextData.Contains(TextDataSearch)).ToList();
            }
            return feed;
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
    }

}
