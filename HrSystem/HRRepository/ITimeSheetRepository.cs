using HRDB;
using HREntity;
using HRModels;
using System.Collections.Generic;

namespace HRRepository
{
    public interface ITimeSheetRepository
    {
        HrSystemDBContext HrSystemDBContext { get; set; }
        bool Delete(int id);
        TimeSheet Save(TimeSheet timeSheet);
        TimeSheet Get(int id);
        List<TimeSheet> GetAll(TimeSheetModel timeSheetModel);
        List<TimeSheet> GetAllQuery(TimeSheetModel timeSheetModel);
    }
}