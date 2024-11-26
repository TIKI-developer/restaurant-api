using MediatR;

namespace Restaurant.Application.Entities.User.Queries.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<UserDetailsViewModel>
    {
        public required Guid Id { get; set; }
    }
}
