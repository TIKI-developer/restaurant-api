using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Address.Queries.GetById
{
    public class GetByIdQuery : IRequest<AddressDetails>
    {
        public required Guid Id { get; set; }
    }
}
