
using System;
using HREntity;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HRModels;
using HRDB;

namespace HRRepository
{
   public  class StageRepository
    {
        HrSystemDBContext HrSystemDBContext { get; set; }

        public StageRepository(HrSystemDBContext hrSystemDBContext)
        {

            HrSystemDBContext = hrSystemDBContext;
        }
        public int TotalRowCount { get; private set; }

        public List<Stage>  GetAll(StageModel stageModel, PageModel pageModel)
        {
            string ColumnName = stageModel.ColumnName;
            string OrderBy = stageModel.OrderBy;
            HrSystemDBContext.Count = HrSystemDBContext.Count + 1;

            var lststage = stageModel.Where(HrSystemDBContext.Stages);
            lststage = stageModel.Sort(lststage);

            if (!(pageModel is null))
            {
                pageModel.SetValues(lststage.ToList());
                lststage = lststage.Skip(pageModel.StartIndex).Take(pageModel.RowPerPage);
            }
            return lststage.ToList();
        }


        public IEnumerable<T> SetStages<T>(IEnumerable<T> lstIstage) where T : IStage
        {
            var lstSTageIds = lstIstage.Select(x => x.StageId).Distinct().ToList();
            HrSystemDBContext.Count = HrSystemDBContext.Count + 1;
            var lststage = HrSystemDBContext.Stages.Where(x => lstSTageIds.Contains(x.Id)).ToList();

            foreach (var item in lstIstage)
            {
                item.Stage = lststage.FirstOrDefault(x => x.Id == item.StageId);
            }

            return lstIstage;
        }




    }
}
