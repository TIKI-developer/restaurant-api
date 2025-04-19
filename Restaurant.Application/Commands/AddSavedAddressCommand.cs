using MediatR;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Application.Commands
{
    public class AddSavedAddressCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
        public required Address Address { get; set; }
        public required Guid UserId { get; set; }
    }
}
