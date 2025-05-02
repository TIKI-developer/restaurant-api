using Restaurant.Domain.Entities;

namespace Restaurant.Application.Interfaces
{
    public interface IJwtProvider
    {
        string Generate(User user);
    }
}
