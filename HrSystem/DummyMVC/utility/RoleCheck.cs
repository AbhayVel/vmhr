using System.Security.Claims;

namespace DummyMVC.utility
{
    public static class RoleCheck
    {

        public static bool IsRole(this ClaimsPrincipal user, string role, string claim )
        {
            if (user.IsInRole(role))
            {
                return true;
            }

           var claims= user.Claims.FirstOrDefault(x => x.Type.ToString().Equals(claim, StringComparison.InvariantCultureIgnoreCase));
            if (claims == null)
            {
                return false;
            }
            if(claims.Value.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }
    }
}
