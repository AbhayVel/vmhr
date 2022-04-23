using HREntity;
using HRModels;
using HRRepository;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
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


        public ClaimsPrincipal Get(string userName, string password)
        {
            var user = UserRepository.Get(userName, password);
            if(user is null)
            {
                return null;
            } else
            {
                user.Password = "";
                user.IsAuthenticated = true;
                user.AuthenticationType = "cookies";

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(user);
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, user.Role));
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                 
                return claimsPrincipal;
            }
        }

        public ClaimsIdentity GetClaimIdentity(string userName, string password)
        {
            var user = UserRepository.Get(userName, password);
            if (user is null)
            {
                return null;
            }
            else
            {
                user.Password = "";
                user.IsAuthenticated = true;
                user.AuthenticationType = "cookies";

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(user);
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, user.Role));
                //ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                return claimsIdentity;
            }
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
