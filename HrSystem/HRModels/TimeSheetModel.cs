using HREntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace HRModels
{
    public class TimeSheetModel : BaseModel, IUserName
    {
        
       
        public string IdSearch { get; set; }

        [MinLength(2)]
        public string UserNameSearch { get; set; }

        public string HeadingSearch { get; set; }
        public string TimeSpendSearch { get; set; }
        public string ShortNotesSearch { get; set; }

        public string TaskStartDateSearch { get; set; }

        public string TaskEndDateSearch { get; set; }

        public string TaskDateSearch { get; set; }
        public string UserName { get ; set ; }

        public IQueryable<TimeSheet> Where(IQueryable<TimeSheet> timeSheets)
        {
            // string whereCondition = string.Empty;
            if (!string.IsNullOrWhiteSpace(UserNameSearch))
            {

                timeSheets = timeSheets.Where(x => x.UserName.Contains(UserNameSearch));

                //whereCondition = whereCondition + $"AND TypeText like '%{TypeTextSearch.Replace("'", "''")}%'";
            }

            if (!string.IsNullOrWhiteSpace(UserName))
            {

                timeSheets = timeSheets.Where(x => x.UserName==UserName);

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

            if (!string.IsNullOrWhiteSpace(HeadingSearch))
            {

                timeSheets = timeSheets.Where(x => x.Heading.Contains(HeadingSearch));

                //whereCondition = whereCondition + $"AND TypeText like '%{TypeTextSearch.Replace("'", "''")}%'";
            }

            if (!string.IsNullOrWhiteSpace(TimeSpendSearch))
            {

                timeSheets = timeSheets.Where(x => x.ShortNotes.Contains(TimeSpendSearch));

                //whereCondition = whereCondition + $"AND TypeText like '%{TypeTextSearch.Replace("'", "''")}%'";
            }

            if (!string.IsNullOrWhiteSpace(ShortNotesSearch))
            {

                timeSheets = timeSheets.Where(x => x.ShortNotes.Contains(ShortNotesSearch));

                //whereCondition = whereCondition + $"AND TypeText like '%{TypeTextSearch.Replace("'", "''")}%'";
            }

            if (!string.IsNullOrWhiteSpace(TaskStartDateSearch))
            {
                DateTime TaskStartDate;
                if (DateTime.TryParse(TaskStartDateSearch, out TaskStartDate))
                {
                    timeSheets = timeSheets.Where(x => x.TaskStartDate == TaskStartDate);
                }
            }

            if (!string.IsNullOrWhiteSpace(TaskEndDateSearch))
            {
                DateTime TaskEndDate;
                if (DateTime.TryParse(TaskEndDateSearch, out TaskEndDate))
                {
                    timeSheets = timeSheets.Where(x => x.TaskEndDate == TaskEndDate);
                }
            }

            if (!string.IsNullOrWhiteSpace(TaskDateSearch))
            {
                DateTime TaskDate;
                if (DateTime.TryParse(TaskDateSearch, out TaskDate))
                {
                    
                    timeSheets = timeSheets.Where(x => x.TaskDate == TaskDate);
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
            if (!string.IsNullOrWhiteSpace(HeadingSearch))
            {
                whereCondition = whereCondition + $"AND ShortNotes like '%{HeadingSearch.Replace("'", "''")}%'";
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
            /*
            if (!string.IsNullOrWhiteSpace(TaskStartDateSearch))
            {
                DateTime taskStartDate;
                if (DateTime.TryParse(TaskStartDateSearch, out taskStartDate))
                {
                    whereCondition = whereCondition + $"AND Id = {taskStartDate}";
                }
            }
            if (!string.IsNullOrWhiteSpace(TaskEndDateSearch))
            {
                int timespend = 0;
                if (int.TryParse(TaskEndDateSearch, out taskEndDate))
                {
                    whereCondition = whereCondition + $"AND Id = {taskEndDate}";
                }
            }
            if (!string.IsNullOrWhiteSpace(TaskDateSearch))
            {
                int timespend = 0;
                if (int.TryParse(TaskDateSearch, out taskDate))
                {
                    whereCondition = whereCondition + $"AND Id = {taskDate}";
                }
            }
            */

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
                else if ("UserName".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderBy(x => x.UserName);
                }
                else if ("Heading".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderBy(x => x.Heading);
                }
                else if ("ShortNotes".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderBy(x => x.ShortNotes);
                }
                else if ("TimeSpend".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderBy(x => x.TimeSpend);
                }
                else if ("TaskStartDate".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderBy(x => x.TaskStartDate);
                }
                else if ("TaskEndDate".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderBy(x => x.TaskEndDate);
                }
                else if ("TaskDate".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderBy(x => x.TaskDate);
                }
            }
            else
            {
                if ("id".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderByDescending(x => x.Id);
                }
                else if ("UserName".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderByDescending(x => x.UserName);
                }
                else if ("Heading".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderByDescending(x => x.Heading);
                }
                else if ("ShortNotes".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderByDescending(x => x.ShortNotes);
                }
                else if ("TimeSpend".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderByDescending(x => x.TimeSpend);
                }
                else if ("TaskStartDate".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderByDescending(x => x.TaskStartDate);
                }
                else if ("TaskEndDate".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderByDescending(x => x.TaskEndDate);
                }
                else if ("TaskDate".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderByDescending(x => x.TaskDate);
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
                else if ("UserName".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    return orderByString + " UserName asc ";
                }
                else if ("Heading".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    return orderByString + " Heading asc ";
                }
                else if ("ShortNotes".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    return orderByString + " ShortNotes asc ";
                }
                else if ("TimeSpend".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    return orderByString + " TimeSpend asc ";
                }
                else if ("TaskStartDate".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    return orderByString + " TaskStartDate asc ";
                }
                else if ("TaskEndDate".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    return orderByString + " TaskEndDate asc ";
                }
                else if ("TaskDate".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    return orderByString + " TaskDate asc ";
                }



            }
            else
            {
                if ("id".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    return orderByString + " id desc ";
                }
                else if ("UserName".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    return orderByString + " UserName desc ";
                }
                else if ("Heading".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    return orderByString + " Heading desc ";
                }
                else if ("ShortNotes".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    return orderByString + " ShortNotes desc ";
                }
                else if ("TimeSpend".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    return orderByString + " TimeSpend desc ";
                }
                else if ("TaskStartDate".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    return orderByString + " TaskStartDate desc ";
                }
                else if ("TaskEndDate".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    return orderByString + " TaskEndDate desc ";
                }
                else if ("TaskDate".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    return orderByString + " TaskDate desc ";
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
            if (!string.IsNullOrWhiteSpace(HeadingSearch))
            {
                timeSheets = timeSheets.Where(x => x.Heading.Contains(HeadingSearch)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(ShortNotesSearch))
            {
                timeSheets = timeSheets.Where(x => x.ShortNotes == ShortNotesSearch).ToList();
            }
            if (!string.IsNullOrWhiteSpace(TimeSpendSearch))
            {
                timeSheets = timeSheets.Where(x => x.TimeSpend.ToString() == TimeSpendSearch).ToList();
            }
            if (!string.IsNullOrWhiteSpace(TaskStartDateSearch))
            {
                timeSheets = timeSheets.Where(x => x.TaskStartDate.ToString() == TaskStartDateSearch).ToList();
            }
            if (!string.IsNullOrWhiteSpace(TaskEndDateSearch))
            {
                timeSheets = timeSheets.Where(x => x.TaskEndDate.ToString() == TaskEndDateSearch).ToList();
            }
            if (!string.IsNullOrWhiteSpace(TaskDateSearch))
            {
                timeSheets = timeSheets.Where(x => x.TaskDate.ToString() == TaskDateSearch).ToList();
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
                else if ("UserName".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderBy(x => x.UserName).ToList();
                }
                else if ("Heading".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderBy(x => x.Heading).ToList();
                }
                else if ("ShortNotes".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderBy(x => x.ShortNotes).ToList();
                }
                else if ("TimeSpend".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderBy(x => x.TimeSpend).ToList();
                }
                else if ("TaskStartDate".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderBy(x => x.TaskStartDate).ToList();
                }
                else if ("TaskEndDate".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderBy(x => x.TaskEndDate).ToList();
                }
                else if ("TaskDate".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderBy(x => x.TaskDate).ToList();
                }


            }
            else
            {
                if ("id".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderByDescending(x => x.Id).ToList();
                }
                else if ("UserName".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderByDescending(x => x.UserName).ToList();
                }
                else if ("Heading".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderByDescending(x => x.Heading).ToList();
                }
                else if ("ShortNotes".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderByDescending(x => x.ShortNotes).ToList();
                }
                else if ("TimeSpend".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderByDescending(x => x.TimeSpend).ToList();
                }
                else if ("TaskStartDate".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderByDescending(x => x.TaskStartDate).ToList();
                }
                else if ("TaskEndDate".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderByDescending(x => x.TaskEndDate).ToList();
                }
                else if ("TaskDate".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderByDescending(x => x.TaskDate).ToList();
                }



            }

            return timeSheets;
        }



    }
}
