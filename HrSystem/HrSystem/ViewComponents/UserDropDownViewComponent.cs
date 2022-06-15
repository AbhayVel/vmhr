using HREntity;
using HRModels;
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
    public class UserDropDownViewComponent : ViewComponent
    {
        IUserService UserService { get; set; }

        public UserDropDownViewComponent(IUserService userService)
        {
            UserService = userService;
        }
        public async Task<ViewViewComponentResult> InvokeAsync(IUserName IUserName)
        {
            UserModel u = new UserModel();
            var claim = UserClaimsPrincipal.Claims.FirstOrDefault(x => x.Type == "UserName");

            u.UserName = claim.Value;
            var userList = UserService.GetWithChild(u, null);
             
            var userData = userList.Select(
              (x) => new SelectListItem(value: x.UserName, text: x.Name, selected: x.UserName == IUserName.UserName)).ToList();

            ViewBag.UserList = userData;

            return View(IUserName);
        }
    }
}
