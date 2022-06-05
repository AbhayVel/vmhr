using HRDB;
using HREntity;
using HRModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRRepository
{
    public interface IFeedRepository
    {
        HrSystemDBContext HrSystemDBContext { get; set; }
        bool Delete(int id);
        Feed Save(Feed feed);
        Feed Get(int id);
        List<Feed> GetAll(FeedModel feedModel);
        List<Feed> GetAllQuery(FeedModel feedModel);
    }
}
