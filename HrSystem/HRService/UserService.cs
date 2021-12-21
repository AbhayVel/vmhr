using HREntity;
using HRModels;
using HRRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRService
{
   public class UserService
   {
      UserRepository UserRepository = new UserRepository();
      public List<User> GetAll(UserModel userModel, PageModel pageModel)
      {
         return UserRepository.GetAll(userModel,pageModel);
      }
   }

  
}
