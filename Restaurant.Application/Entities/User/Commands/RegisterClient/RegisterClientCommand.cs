using MediatR;

namespace Restaurant.Application.Entities.User.Commands.RegisterClient
{
    public class RegisterClientCommand : IRequest<Guid>
    {
        public string? Name { get; set; }
        public required string Number { get; set; }
        public required string Password { get; set; }
    }
}
