using MediatR;


namespace Restaurant.Application.Entities.User.Commands.Login
{
    public class LoginCommand : IRequest<string>
    {
        public string? Name { get; set; }
        public required string Number { get; set; }
    }
}
