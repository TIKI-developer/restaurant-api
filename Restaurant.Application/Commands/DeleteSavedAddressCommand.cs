using MediatR;

namespace Restaurant.Application.Commands
{
    public class DeleteSavedAddressCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
