using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Address.Queries.GetById
{
    public class GetAddressByIdQuery : IRequest<AddressDetails>
    {
        public required Guid Id { get; set; }
    }
}
