using HRDB;
using HREntity;
using HRModels;
using System.Collections.Generic;

namespace HRRepository
{
    public interface IFeedTypeRepository
    {
        HrSystemDBContext HrSystemDBContext { get; set; }
        bool Delete(int id);
        FeedType Save(FeedType feedType);
        FeedType Get(int id);
        List<FeedType> GetAll(FeedTypeModel feedTypeModel);
        List<FeedType> GetAllQuery(FeedTypeModel feedTypeModel);
    }
}