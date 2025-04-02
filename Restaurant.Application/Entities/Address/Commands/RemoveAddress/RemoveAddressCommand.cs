using MediatR;

namespace Restaurant.Application.Entities.Address.Commands.RemoveAddress
{
    public class RemoveAddressCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
