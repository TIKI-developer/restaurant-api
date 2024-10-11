using MediatR;


namespace Restaurant.Application.Users.Commands.Login
{
    public class LoginUserCommand : IRequest<string>
    {
        public required string Number { get; set; }
        public required string Password { get; set; }
    }
}
