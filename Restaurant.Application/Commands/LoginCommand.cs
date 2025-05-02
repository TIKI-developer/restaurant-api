using MediatR;


namespace Restaurant.Application.Commands
{
    public class LoginCommand : IRequest<string>
    {
        public string? Name { get; set; }
        public required string PhoneNumber { get; set; }
        public string? FncToken { get; set; }
    }
}
