using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetSavedAddressListByUserQuery : IRequest<SavedAddressList>
    {
        public required Guid UserId { get; set; }
    }
}
