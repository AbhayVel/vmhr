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
    public class FeedTypeRepository
    {

        private string _query="Select Id,TypeText from FeedType Where  1=1";

        private string _queryCount = "Select Count(1) as count from FeedType Where  1=1";
        public HrSystemDBContext HrSystemDBContext { get; set; } //Instance variable 

        public FeedTypeRepository()
        {
            HrSystemDBContext = new HrSystemDBContext();
        }


        public List<FeedType> GetAllQuery(FeedTypeModel feedTypeModel)
        {
            var countQuery = _queryCount + feedTypeModel.Where();
            var count = HrSystemDBContext.CountValue(countQuery);
            var query = _query + feedTypeModel.Where() + feedTypeModel.Sort() + feedTypeModel.PageModel.SetValues(count);
            var result = HrSystemDBContext.FeedType.FromSqlRaw(query).ToList();
            return result;
        }


        public List<FeedType> GetAll(FeedTypeModel feedTypeModel)
        {
            IQueryable<FeedType> feedTypes = HrSystemDBContext.FeedType;
            feedTypes= feedTypeModel.Where(feedTypes);
            var count = feedTypes.Count();
            feedTypes= feedTypeModel.Sort(feedTypes);
            feedTypes = feedTypeModel.PageModel.SetValues(feedTypes, count);
            var result = feedTypes.ToList();
            return result;
        }

    }
}
