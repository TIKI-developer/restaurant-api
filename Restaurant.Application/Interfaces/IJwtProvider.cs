using Restaurant.Domain.User;

namespace Restaurant.Application.Interfaces
{
    public interface IJwtProvider
    {
        string Generate(UserModel user);
    }
}
