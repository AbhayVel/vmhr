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
    public class TimeSheetRepository
    {
        private string _query = "Select Id,UserName,Heading,ShortNotes,TimeSpend,TaskStartDate,TaskEndDate,TaskDate from TimeSheet Where  1=1";

        private string _queryCount = "Select Count(1) as count from TimeSheet Where  1=1";
        public HrSystemDBContext HrSystemDBContext { get; set; }

        public TimeSheetRepository()
        {
            HrSystemDBContext = new HrSystemDBContext();
        }

        public List<TimeSheet> GetAllQuery(TimeSheetModel timeSheetModel)
        {
            var countQuery = _queryCount + timeSheetModel.Where();
            var count = HrSystemDBContext.CountValue(countQuery);
            var query = _query + timeSheetModel.Where() + timeSheetModel.Sort() + timeSheetModel.PageModel.SetValues(count);
            var result = HrSystemDBContext.TimeSheet.FromSqlRaw(query).ToList();
            return result;
        }

        public List<TimeSheet> GetAll(TimeSheetModel timeSheetModel)
        {
            IQueryable<TimeSheet> timeSheets = HrSystemDBContext.TimeSheet;
            timeSheets = timeSheetModel.Where(timeSheets);
            var count = timeSheets.Count();
            timeSheets = timeSheetModel.Sort(timeSheets);
            timeSheets = timeSheetModel.PageModel.SetValues(timeSheets, count);
            var result = timeSheets.ToList();
            return result;
        }
    }
}
