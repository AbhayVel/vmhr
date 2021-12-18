using HREntity;
using HRModels;
using HRRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRService
{
    public class ApplicationService
    {
        ApplicationRepository ApplicationRepository = new ApplicationRepository();

        public List<Application> GetAll(ApplicationModel applicationModel, PageModel pageModel)
        {
            return ApplicationRepository.GetAll(applicationModel, pageModel);
        }
    }
}
