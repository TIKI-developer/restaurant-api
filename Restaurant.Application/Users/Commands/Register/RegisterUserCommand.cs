using MediatR;

namespace Restaurant.Application.Users.Commands.CreateUser
{
    public class RegisterUserCommand : IRequest<Guid>
    {
        public required Guid Id { get; set; }
        public string? Name { get; set; }
        public required string Number { get; set; }
        public required string Password { get; set; }
    }
}
