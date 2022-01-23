using HREntity;
using HRService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrSystem.ViewComponents
{
    public class StageViewComponent : ViewComponent
    {
        StageService StageService { get; set; }

        public StageViewComponent(StageService stageService)
        {
            StageService = stageService;
        }
        public async Task<ViewViewComponentResult> InvokeAsync(IStage stage)
        {
            var stageList = await StageService.GetWithSelectAsync();

            ViewBag.StageId = stageList.Select(x => new SelectListItem(x.StatusLabel, x.Id.ToString()));

            return View(stage);
        }
    }
}
