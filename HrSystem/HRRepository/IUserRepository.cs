using HRDB;
using HREntity;
using HRModels;
using System.Collections.Generic;

namespace HRRepository
{
   public interface IUserRepository
   {
      HrSystemDBContext HrSystemDBContext { get; set; }

      void Delete(int id);
      void Delete(User user);
      User Get(int id);
      List<User> GetAll(UserModel userModel, PageModel pageModel);
      User Save(User user);

      User Get(string userName, string password);
        List<User> GetWithChild(IUserName userModel, PageModel pageModel);
    }
}