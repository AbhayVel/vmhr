using HREntity;
using HRModels;
using HRRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRService
{
   public class UserService : IUserService
   {
      IUserRepository UserRepository { get; set; }

      public UserService(IUserRepository userRepository)
      {
         UserRepository = userRepository;
      }





      public List<User> GetAll(UserModel userModel, PageModel pageModel)
      {
         return UserRepository.GetAll(userModel, pageModel);
      }

      public User Save(User user)
      {
         return UserRepository.Save(user);
      }
      public User Get(int id)
      {
         return UserRepository.Get(id);
      }

      public void Delete(int id)
      {
         UserRepository.Delete(id);
      }
      public void Delete(User user)
      {
         UserRepository.Delete(user);
      }
   }
}
