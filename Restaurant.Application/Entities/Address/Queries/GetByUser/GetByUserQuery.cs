using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Address.Queries.GetByUser
{
    public class GetByUserQuery : IRequest<AddressList>   
    {
        public required Guid UserId { get; set; }
    }
}
