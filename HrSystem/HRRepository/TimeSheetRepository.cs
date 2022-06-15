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
        private string _query = "with usertbl as ( Select UserName, ReportsTo, 0 as level From [dbo].[user] Where userName='{0}' Union ALl Select u.UserName, u.ReportsTo ,ut.level+1 From [dbo].[user] u  inner Join usertbl ut on ut.UserName=u.ReportsTo ) Select u.Id,u.UserName,Heading,ShortNotes,TimeSpend,TaskStartDate,TaskEndDate,TaskDate from [dbo].[TimeSheet] u inner join usertbl ut on u.UserName=ut.UserName Where  1=1";

        private string _queryCount = "with usertbl as ( Select UserName, ReportsTo, 0 as level From [dbo].[user] Where userName='{0}' Union ALl Select u.UserName, u.ReportsTo ,ut.level+1 From [dbo].[user] u  inner Join usertbl ut on ut.UserName=u.ReportsTo )  Select Count(1) as count from [dbo].[TimeSheet] u inner join usertbl ut on u.UserName=ut.UserName Where  1=1";
        public HrSystemDBContext HrSystemDBContext { get; set; }

        public TimeSheetRepository()
        {
            HrSystemDBContext = new HrSystemDBContext();
        }

        public List<TimeSheet> GetAll(TimeSheetModel timeSheetModel)
        {
            _queryCount = String.Format(_queryCount, timeSheetModel.UserName);
            _query = String.Format(_query, timeSheetModel.UserName);
            var countQuery = _queryCount + timeSheetModel.Where();
            var count = HrSystemDBContext.CountValue(countQuery);
            var query = _query + timeSheetModel.Where() + timeSheetModel.Sort() + timeSheetModel.PageModel.SetValues(count);
            var result = HrSystemDBContext.TimeSheet.FromSqlRaw(query).ToList();
            return result;
        }

        public List<TimeSheet> GetAllQuery(TimeSheetModel timeSheetModel)
        {
            IQueryable<TimeSheet> timeSheets = HrSystemDBContext.TimeSheet;
            timeSheets = timeSheetModel.Where(timeSheets);
            var count = timeSheets.Count();
            timeSheets = timeSheetModel.Sort(timeSheets);
            timeSheets = timeSheetModel.PageModel.SetValues(timeSheets, count);
            var result = timeSheets.ToList();
            return result;
        }

        public TimeSheet Get(int id)
        {
            var result = HrSystemDBContext.TimeSheet.FirstOrDefault(x => x.Id == id);
            return result;
        }


        public bool Delete(int id)
        {
            var result = HrSystemDBContext.TimeSheet.FirstOrDefault(x => x.Id == id);

            if (result != null)
            {
                HrSystemDBContext.TimeSheet.Remove(result);

                HrSystemDBContext.SaveChanges();
                return true;
            }
            return false;
        }
        public TimeSheet Save(TimeSheet timeSheet)
        {



            if (!timeSheet.Id.HasValue || timeSheet.Id.Value == 0)
            {
                timeSheet.Id = null;
                HrSystemDBContext.TimeSheet.Add(timeSheet);
            }
            else
            {
                // var result = HrSystemDBContext.FeedType.AsNoTracking().FirstOrDefault(x => x.Id == feedType.Id);

                var result = HrSystemDBContext.TimeSheet.FirstOrDefault(x => x.Id == timeSheet.Id);
                if (result != null)
                {


                    result.UserName = timeSheet.UserName;
                    //HrSystemDBContext.Attach(feedType).State = EntityState.Modified;
                }
                else
                {
                    throw new Exception("Requested object doesnot exists");
                }

            }
            HrSystemDBContext.SaveChanges();

            return timeSheet;
        }
    }
}
