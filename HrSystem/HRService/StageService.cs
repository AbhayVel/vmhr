using HREntity;
using HRModels;
using HRRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRService
{
    public class StageService
    {
        StageRepository StageRepository { get; set; }

       public StageService(StageRepository stageRepository)
        {
            StageRepository = stageRepository;
        }
        public List<Stage> GetAll(StageModel stageModel, PageModel pageModel)

        {
            return StageRepository.GetAll(stageModel,pageModel);
        }


        public List<Stage> GetWithSelect()

        {
            var lst= GetAll(new StageModel(), null);

            lst.Insert(0, new Stage { Id = 0, StatusLabel = "Select" });
            return lst;
        }

    }

}