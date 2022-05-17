using HRDB;
using HREntity;
using HRModels;
using System.Collections.Generic;

namespace HRRepository
{
    public interface IFeedTypeRepository
    {
        HrSystemDBContext HrSystemDBContext { get; set; }

        List<FeedType> GetAll(FeedTypeModel feedTypeModel);
        List<FeedType> GetAllQuery(FeedTypeModel feedTypeModel);
    }
}