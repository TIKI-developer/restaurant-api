using MediatR;

namespace Restaurant.Application.Commands
{
    public class DeleteAddressCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
