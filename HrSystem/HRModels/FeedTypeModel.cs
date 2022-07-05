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
       public List<FeedType> FeedType { get; set; }
        public string IdSearch { get; set; }

        public string TypeTextSearch { get; set; }


        public IQueryable<FeedType> Where(IQueryable<FeedType> feedTypes)
        {
           // string whereCondition = string.Empty;
            if (!string.IsNullOrWhiteSpace(TypeTextSearch))
            {

                feedTypes= feedTypes.Where(x=>x.TypeText.Contains(TypeTextSearch));

                //whereCondition = whereCondition + $"AND TypeText like '%{TypeTextSearch.Replace("'", "''")}%'";
            }

            if (!string.IsNullOrWhiteSpace(IdSearch))
            {
                int id = 0;
                if (int.TryParse(IdSearch, out id))
                {
                    feedTypes = feedTypes.Where(x => x.Id==id);
                }
            }

            return feedTypes;

        }

        public string Where()
        {
            string whereCondition=string.Empty;
            if (!string.IsNullOrWhiteSpace(TypeTextSearch))
            {
                whereCondition = whereCondition + $"AND TypeText like '%{TypeTextSearch.Replace("'", "''")}%'";
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

        public IQueryable<FeedType> Sort(IQueryable<FeedType> feedTypes)
        {
            string orderByString = " Order By ";
            if ("asc".Equals(OrderBy, System.StringComparison.OrdinalIgnoreCase))
            {
                if ("id".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feedTypes= feedTypes.OrderBy(x => x.Id);
                }
                else if ("TypeText".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feedTypes = feedTypes.OrderBy(x => x.TypeText);
                }
            }
            else
            {
                if ("id".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feedTypes = feedTypes.OrderByDescending(x => x.Id);
                }
                else if ("TypeText".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feedTypes = feedTypes.OrderByDescending(x => x.TypeText);
                }
            }

            return feedTypes;
        }


        public string Sort()
        {
            string orderByString = " Order By ";
            if ("asc".Equals(OrderBy, System.StringComparison.OrdinalIgnoreCase))
            {
                if ("id".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    return orderByString + " id asc ";
                }
                else if ("TypeText".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    return orderByString + " TypeText asc ";
                }
            }
            else
            {
                if ("id".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    return orderByString + " id desc ";
                }
                else if ("TypeText".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    return orderByString + " TypeText desc ";
                }  
            }

            return orderByString + " id asc ";
        }


        public List<FeedType> Where(List<FeedType> feedTypes)
        {
            if (!string.IsNullOrWhiteSpace(IdSearch))
            {
                feedTypes = feedTypes.Where(x => x.Id.ToString() == IdSearch).ToList();
            }
            if (!string.IsNullOrWhiteSpace(TypeTextSearch))
            {
                feedTypes = feedTypes.Where(x => x.TypeText.Contains(TypeTextSearch)).ToList();
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
                else if ("TextData".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feedTypes = feedTypes.OrderBy(x => x.TypeText).ToList();
                }


            }
            else
            {
                if ("id".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feedTypes = feedTypes.OrderByDescending(x => x.Id).ToList();
                }
                else if ("TextData".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    feedTypes = feedTypes.OrderByDescending(x => x.TypeText).ToList();
                }


            }

            return feedTypes;
        }

    }
}
