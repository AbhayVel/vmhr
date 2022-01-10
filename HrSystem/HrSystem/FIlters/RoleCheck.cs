using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HrSystem.FIlters
{
    public static class RoleCheck
    {
        public static bool IsInRoleCheck(this ClaimsPrincipal claimsPrincipal, string roles)
        {
          var lstRole=  roles.Split(",").Select(x => x.Trim().ToLower()).ToList();

            string role = claimsPrincipal.FindFirstValue(ClaimTypes.Role).ToLower();

            if (lstRole.IndexOf(role) > -1)
            {
                return true;
            } else
            {
                return false;
            }

           

        }
    }
}
