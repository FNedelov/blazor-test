using System.Security.Claims;
using TestApp.Authentication.Models;

namespace TestApp.Authentication
{
    public static class Authenticator
    {
        public static ClaimsIdentity GetClaimsIdentity(UserData userData)
        {
            ClaimsIdentity identity = new(new Claim[] 
            { 
                new Claim(ClaimTypes.Name, userData?.Name ?? string.Empty)
            }, "AuthInfo");

            List<string> userRoles = userData?.Roles?.Split(',').ToList() ?? new();
            userRoles.ForEach(x => identity.AddClaim(new Claim(ClaimTypes.Role, x)));

            return identity;
        }
    }
}