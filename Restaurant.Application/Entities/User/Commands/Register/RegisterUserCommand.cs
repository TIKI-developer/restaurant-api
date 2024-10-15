using MediatR;

namespace Restaurant.Application.Entities.User.Commands.Register
{
    public class RegisterUserCommand : IRequest<Guid>
    {
        public string? Name { get; set; }
        public required string Number { get; set; }
        public required string Password { get; set; }
    }
}
