using Restaurant.Application.Entities.User.Commands.Login;

namespace Restaurant.Application.Interfaces
{
    public interface IAdminIdentityProvider
    {
        bool IsAdmin(LoginCommand loginUserCommand);
    }
}
