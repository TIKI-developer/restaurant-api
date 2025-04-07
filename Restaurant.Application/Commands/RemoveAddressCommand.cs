using MediatR;

namespace Restaurant.Application.Commands
{
    public class RemoveAddressCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
