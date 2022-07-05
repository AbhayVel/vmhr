using HRService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WebApiPractise.Controllers
{

    public class UserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    [ApiController]
    [Route("[controller]/[action]")]
    public class LoginController : ControllerBase
    {
        public IUserService UserService { get; set; }
        public LoginController(IUserService UserService)
        {
            this.UserService = UserService;
        }

        [HttpPost]
        public ActionResult<UserModel> Login(UserModel userModel)
        {
          var identity=  UserService.GetClaimIdentity(userModel.UserName, userModel.Password);

            var incryptKey = new SecurityTokenDescriptor
            {
                Subject = identity,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("012345678901234567")),
                SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.Now.AddDays(1)


            };

            var tokenJwt = new JwtSecurityTokenHandler();
          var token=  tokenJwt.CreateToken(incryptKey);
         var str=   tokenJwt.WriteToken(token);

            return Ok(str);
        }
    }
}
