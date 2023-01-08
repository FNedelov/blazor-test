using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using TestApp.Authentication;
using TestApp.Authentication.Models;

namespace TestApp.Web.HelperClasses
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal _claimsPrincipal = new(new ClaimsIdentity());

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(_claimsPrincipal)));
        }

        public async Task SetAuthInfo(UserData? user)
        {
            if(user == null)
            {
                _claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
            }
            else
            {
                _claimsPrincipal = new ClaimsPrincipal(Authenticator.GetClaimsIdentity(user));
            }

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}