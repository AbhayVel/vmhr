using HREntity;
using HRModels;
using System.Collections.Generic;

namespace HRService
{
   public interface IUserService
   {
      void Delete(int id);
      void Delete(User user);
      User Get(int id);
      List<User> GetAll(UserModel userModel, PageModel pageModel);
      User Save(User user);
   }
}