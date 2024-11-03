using MediatR;

namespace Restaurant.Application.Entities.User.Queries.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<ClientDetailsViewModel>
    {
        public required Guid Id { get; set; }
    }
}
