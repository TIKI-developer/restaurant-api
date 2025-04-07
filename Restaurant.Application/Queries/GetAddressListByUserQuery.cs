using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetAddressListByUserQuery : IRequest<AddressList>
    {
        public required Guid UserId { get; set; }
    }
}
