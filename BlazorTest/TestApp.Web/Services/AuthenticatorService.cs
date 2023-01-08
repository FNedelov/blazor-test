﻿using TestApp.Authentication.Models;
using TestApp.Web.HelperClasses;

namespace TestApp.Web.Services
{
    public class AuthenticatorService
    {
        CustomAuthenticationStateProvider _custAuthProvider;
        private List<UserData> _users = new()
        {
            new UserData { Name = "user1", Roles = "user" },
            new UserData { Name = "admin1", Roles = "admin" },
            new UserData { Name = "batman", Roles = "admin, batman" }
        };

        public AuthenticatorService(IServiceProvider serviceProvider)
        {
            _custAuthProvider = serviceProvider.GetRequiredService<CustomAuthenticationStateProvider>();
        }

        public async Task SetAuthInfo(string userName)
        {
            UserData? user = _users.Where(x => x.Name == userName).FirstOrDefault();
            await _custAuthProvider.SetAuthInfo(user);
        }
    }
}