using Microsoft.Extensions.Options;
using Restaurant.Application.Entities.User.Commands.Login;
using Restaurant.Application.Interfaces;

namespace Restaurant.Security
{
    public class AdminIdentityProvider : IAdminIdentityProvider
    {
        private readonly List<string> _adminNumbers;
        private readonly AdminOptions _adminOptions;

        public AdminIdentityProvider(IOptions<AdminOptions> options)
        {
            _adminOptions = options.Value;
            _adminNumbers = [.. _adminOptions.Numbers];
        }

        public bool IsAdmin(LoginCommand loginUserCommand)
        {
            if (_adminNumbers.Contains(loginUserCommand.Number))
            {
                return true;
            }

            return false;
        }
    }

    public class AdminOptions
    {
        public string[] Numbers { get; set; } = [];
    }
}
