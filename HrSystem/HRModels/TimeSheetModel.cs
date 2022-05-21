using HREntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRModels
{
    public class TimeSheetModel : BaseModel
    {
        

        public string IdSearch { get; set; }

        public string UserNameSearch { get; set; }
        public string TimeSpendSearch { get; set; }
        public string ShortNotesSearch { get; set; }

        public IQueryable<TimeSheet> Where(IQueryable<TimeSheet> timeSheets)
        {
            // string whereCondition = string.Empty;
            if (!string.IsNullOrWhiteSpace(UserNameSearch))
            {

                timeSheets = timeSheets.Where(x => x.UserName.Contains(UserNameSearch));

                //whereCondition = whereCondition + $"AND TypeText like '%{TypeTextSearch.Replace("'", "''")}%'";
            }

            if (!string.IsNullOrWhiteSpace(IdSearch))
            {
                int id = 0;
                if (int.TryParse(IdSearch, out id))
                {
                    timeSheets = timeSheets.Where(x => x.Id == id);
                }
            }

            return timeSheets;

        }

        public string Where()
        {
            string whereCondition = string.Empty;

            if (!string.IsNullOrWhiteSpace(IdSearch))
            {
                whereCondition = whereCondition + $"AND TextData like '%{UserNameSearch.Replace("'", "''")}%'";
            }
            if (!string.IsNullOrWhiteSpace(UserNameSearch))
            {
                int id = 0;
                if (int.TryParse(IdSearch, out id))
                {
                    whereCondition = whereCondition + $"AND Id = {id}";
                }
            }
            if (!string.IsNullOrWhiteSpace(ShortNotesSearch))
            {
                whereCondition = whereCondition + $"AND ShortNotes like '%{ShortNotesSearch.Replace("'", "''")}%'";
            }
            if (!string.IsNullOrWhiteSpace(TimeSpendSearch))
            {
                int timespend = 0;
                if (int.TryParse(TimeSpendSearch, out timespend))
                {
                    whereCondition = whereCondition + $"AND Id = {timespend}";
                }
            }

            return whereCondition;
        }

        public IQueryable<TimeSheet> Sort(IQueryable<TimeSheet> timeSheets)
        {
            string orderByString = " Order By ";
            if ("asc".Equals(OrderBy, System.StringComparison.OrdinalIgnoreCase))
            {
                if ("id".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderBy(x => x.Id);
                }
                else if ("TypeText".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderBy(x => x.UserName);
                }
            }
            else
            {
                if ("id".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderByDescending(x => x.Id);
                }
                else if ("TextData".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderByDescending(x => x.UserName);
                }
            }

            return timeSheets;
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
                else if ("TextData".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    return orderByString + " TextData asc ";
                }


            }
            else
            {
                if ("id".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    return orderByString + " id desc ";
                }
                else if ("TextData".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    return orderByString + " TextData desc ";
                }


            }

            return orderByString + " id asc ";
        }
        public List<TimeSheet> Where(List<TimeSheet> timeSheets)
        {
            if (!string.IsNullOrWhiteSpace(IdSearch))
            {
                timeSheets = timeSheets.Where(x => x.Id.ToString() == IdSearch).ToList();
            }
            if (!string.IsNullOrWhiteSpace(UserNameSearch))
            {
                timeSheets = timeSheets.Where(x => x.UserName.Contains(UserNameSearch)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(ShortNotesSearch))
            {
                timeSheets = timeSheets.Where(x => x.ShortNotes == ShortNotesSearch).ToList();
            }
            if (!string.IsNullOrWhiteSpace(TimeSpendSearch))
            {
                timeSheets = timeSheets.Where(x => x.TimeSpend.ToString() == TimeSpendSearch).ToList();
            }

            return timeSheets;
        }

        public List<TimeSheet> Sort(List<TimeSheet> timeSheets)
        {
            if ("asc".Equals(OrderBy, System.StringComparison.OrdinalIgnoreCase))
            {
                if ("id".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderBy(x => x.Id).ToList();
                }
                else if ("TextData".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderBy(x => x.UserName).ToList();
                }

                
            }
            else
            {
                if ("id".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderByDescending(x => x.Id).ToList();
                }
                else if ("TextData".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderByDescending(x => x.UserName).ToList();
                }

                
            }

            return timeSheets;
        }



    }
}
