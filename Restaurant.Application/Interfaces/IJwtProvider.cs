using Restaurant.Domain;

namespace Restaurant.Application.Interfaces
{
    public interface IJwtProvider
    {
        string Generate(User user);
    }
}
