using TestApp.Authentication.Models;
using TestApp.Web.HelperClasses;

namespace TestApp.Web.Services
{
    public class AuthenticatorService
    {
        CustomAuthenticationStateProvider _custAuthProvider;
        private List<UserData> _users = new()
        {
            new UserData { Name = "user1", Roles = "User" },
            new UserData { Name = "admin1", Roles = "Admin" },
            new UserData { Name = "batman", Roles = "Batman" }
        };

        public AuthenticatorService(IServiceProvider serviceProvider)
        {
            _custAuthProvider = serviceProvider.GetRequiredService<CustomAuthenticationStateProvider>();
        }

        public async Task SetAuthInfo(string userName)
        {
#warning get here the roles!!!
            UserData? user = _users.Where(x => x.Name == userName).FirstOrDefault();
            await _custAuthProvider.SetAuthInfo(user);
        }
    }
}
