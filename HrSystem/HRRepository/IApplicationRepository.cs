using HRDB;
using HREntity;
using HRModels;
using System.Collections.Generic;

namespace HRRepository
{
    public interface IApplicationRepository
    {
        HrSystemDBContext HrSystemDBContext { get; set; }

        void Delete(Application application);
        void Delete(int id);
        Application Get(int id);
        List<Application> GetAll(ApplicationModel applicationModel, PageModel pageModel);
        List<Application> GetAll(string columnName, string orderBy, string IdSearch, string NameSearch, PageModel pageModel);
        List<Application> GetAllWIthEntity(ApplicationModel applicationModel, PageModel pageModel);
        Application Save(Application application);
    }
}