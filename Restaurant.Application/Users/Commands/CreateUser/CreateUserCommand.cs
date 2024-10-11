using MediatR;

namespace Restaurant.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public required string Number { get; set; }
        public required string Password { get; set; }
    }
}
