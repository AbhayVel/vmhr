using HREntity;
using HRModels;
using HRRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRService
{
   public class StageService
   {
      StageRepository StageRepository { get; set; }

      public StageService(StageRepository stageRepository)
      {
         StageRepository = stageRepository;
      }
      public async System.Threading.Tasks.Task<List<Stage>> GetAllAsync(StageModel stageModel, PageModel pageModel)

      {
         

         return await StageRepository.GetAllAsync(stageModel, pageModel);
      }

      //public async Task< List<Stage>>  GetAll(StageModel stageModel, PageModel pageModel)
      //{
      //   var lstStage=  StageRepository.GetAllAsync(stageModel, pageModel);
        
      //   return await lstStage;
      //}
      public async Task<List<Stage>> GetWithSelectAsync()

      {
         var lst = await GetAllAsync(new StageModel(), null);

         lst.Insert(0, new Stage { Id = 0, StatusLabel = "Select" });
         return lst;
      }

   }

}