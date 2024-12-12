using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.User.Queries.GetById
{
    public class GetByIdQuery : IRequest<UserDetails>
    {
        public required Guid Id { get; set; }
    }
}
