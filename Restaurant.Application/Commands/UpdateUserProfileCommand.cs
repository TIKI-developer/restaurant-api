using MediatR;

namespace Restaurant.Application.Commands
{
    public class UpdateUserProfileCommand : IRequest<Unit>
    {
        public required Guid Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
