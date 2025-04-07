using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Address.Queries.GetByUser
{
    public class GetAddressListByUserQuery : IRequest<AddressList>   
    {
        public required Guid UserId { get; set; }
    }
}
