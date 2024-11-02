using MediatR;

namespace Restaurant.Application.Entities.User.Commands.RegisterAdmin
{
    public class RegisterAdminCommand : IRequest<Guid>, IRegisterUserCommand
    {
        public required string Number { get; set; }
        public required string Password { get; set; }
    }
}
