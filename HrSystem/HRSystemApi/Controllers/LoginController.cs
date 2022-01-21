using HREntity;
using HRModels;
using HRService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystemApi.Controllers
{

    [ApiController]
 [Route("api/[Controller]/[Action]/{id?}")]
    [Route("api/[Controller]")]
    [AllowAnonymous]
    public class LoginsController : ControllerBase
    {

        IUserService UserService { get; set; }
      

        public LoginsController(IUserService userService

            )
        {
            UserService = userService;
           
        }

  
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {

            var userLogin = UserService.GetClaimIdentity(user.UserName, user.Password);
            if (userLogin != null)
            {
                try
                {
                    var byteKey = Encoding.ASCII.GetBytes("012345678901234567");
                    var std = new SecurityTokenDescriptor
                    {
                        Subject = userLogin,
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(byteKey),
                        SecurityAlgorithms.HmacSha256Signature),
                        Expires = DateTime.Now.AddMinutes(20)


                    };

                    var jwt = new JwtSecurityTokenHandler();
                    var token = jwt.CreateToken(std);
                    var jsonString = jwt.WriteToken(token);

                    return Content(jsonString);

                }
                catch (Exception ex)
                {

                }

                
                return NotFound("UserName/Password not found.");
            }
            else
            {

                return NotFound("UserName/Password not found.");
            }
           
        }


       



       


             
     
    }
}
