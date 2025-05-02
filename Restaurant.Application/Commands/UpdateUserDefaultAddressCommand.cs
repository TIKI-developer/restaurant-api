using MediatR;

namespace Restaurant.Application.Commands
{
    public class UpdateUserDefaultAddressCommand : IRequest
    {
        public required Guid UserId { get; set; }
        public required Guid DefaultAddressId { get; set; }
    }
}
