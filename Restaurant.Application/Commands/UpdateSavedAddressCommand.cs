using MediatR;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Application.Commands
{
    public class UpdateSavedAddressCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required Address Address { get; set; }
    }
}
