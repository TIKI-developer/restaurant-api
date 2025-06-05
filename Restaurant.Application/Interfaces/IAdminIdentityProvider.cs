using Restaurant.Application.Commands;

namespace Restaurant.Application.Interfaces
{
    public interface IAdminIdentityProvider
    {
        bool IsAdmin(LoginCommand loginUserCommand);
    }
}
