using MediatR;
using Restaurant.Domain;

namespace Restaurant.Application.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<User>
    {
    }
}
