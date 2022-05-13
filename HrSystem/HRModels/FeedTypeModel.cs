using HREntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HRModels
{
    public class FeedTypeModel : BaseModel
    {
        //string orderBy, string orderType, string IdSearch, string TypeTextSearch

        

        public string IdSearch { get; set; }

        public string TypeTextSearch { get; set; }

        public List<FeedType> Where(List<FeedType> feedTypes)
        {
            if (!string.IsNullOrWhiteSpace(TypeTextSearch))
            {
                feedTypes = feedTypes.Where(x => x.TypeText.Contains(TypeTextSearch)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(IdSearch))
            {

                feedTypes = feedTypes.Where(x => x.Id.ToString() == IdSearch).ToList();
            }

            return feedTypes;

        }


        public List<FeedType> Sort(List<FeedType> feedTypes)
        {
            if ("asc".Equals(OrderBy, System.StringComparison.OrdinalIgnoreCase))
            {
                if ("id".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feedTypes = feedTypes.OrderBy(x => x.Id).ToList();
                }
                else if ("TypeText".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feedTypes = feedTypes.OrderBy(x => x.TypeText).ToList();
                }
                OrderBy = "desc";
            }
            else
            {
                if ("id".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feedTypes = feedTypes.OrderByDescending(x => x.Id).ToList();
                }
                else if ("TypeText".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feedTypes = feedTypes.OrderByDescending(x => x.TypeText).ToList();
                }
                OrderBy = "asc";
            }

            return feedTypes;

        }

    }
}
