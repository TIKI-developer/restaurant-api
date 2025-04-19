using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetSavedAddressByIdQuery : IRequest<SavedAddressDetails>
    {
        public required Guid Id { get; set; }
    }
}
