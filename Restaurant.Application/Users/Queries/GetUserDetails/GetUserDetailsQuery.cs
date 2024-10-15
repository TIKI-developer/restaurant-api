using MediatR;
using Restaurant.Domain;

namespace Restaurant.Application.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<UserDetailsViewModel>
    {
        public required Guid Id { get; set; }
    }
}
