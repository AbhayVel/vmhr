
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
        HrSystemDBContext hrSystemDBContext = new HrSystemDBContext();

        public StageRepository()
        { 
        }
        public int TotalRowCount { get; private set; }

        public List<Stage>  GetAll(StageModel stageModel, PageModel pageModel)
        {
            string ColumnName = stageModel.ColumnName;
            string OrderBy = stageModel.OrderBy;
           
             var lststage = stageModel.Where(hrSystemDBContext.Stages);
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
            var lstStageIds = lstIstage.Select(x => x.StageId).Distinct().ToList();

          var lststage = hrSystemDBContext.Stages.Where(x => lstStageIds.Contains(x.Id)).ToList();

            foreach (var item in lstIstage)
            {
                item.Stage = lststage.FirstOrDefault(x => x.Id == item.StageId);
            }

            return lstIstage;
        }




    }
}
