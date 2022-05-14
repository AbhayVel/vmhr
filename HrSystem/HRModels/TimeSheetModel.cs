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

        public string TextDataSearch { get; set; }
        public string TimeSpendSearch { get; set; }
        public string ShortNotesSearch { get; set; }

        public List<TimeSheet> Where(List<TimeSheet> timeSheets)
        {
            if (!string.IsNullOrWhiteSpace(IdSearch))
            {
                timeSheets = timeSheets.Where(x => x.Id.ToString() == IdSearch).ToList();
            }
            if (!string.IsNullOrWhiteSpace(TextDataSearch))
            {
                timeSheets = timeSheets.Where(x => x.TextData.Contains(TextDataSearch)).ToList();
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
                    timeSheets = timeSheets.OrderBy(x => x.TextData).ToList();
                }

                OrderBy = "desc";
            }
            else
            {
                if ("id".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderByDescending(x => x.Id).ToList();
                }
                else if ("TextData".Equals(ColumnName, System.StringComparison.OrdinalIgnoreCase))
                {
                    timeSheets = timeSheets.OrderByDescending(x => x.TextData).ToList();
                }

                OrderBy = "asc";
            }

            return timeSheets;
        }



    }
}
