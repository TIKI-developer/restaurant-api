using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetUserByIdQuery : IRequest<UserDetails>
    {
        public required Guid Id { get; set; }
    }
}
