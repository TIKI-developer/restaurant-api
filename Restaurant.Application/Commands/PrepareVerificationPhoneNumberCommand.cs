using MediatR;

namespace Restaurant.Application.Commands
{
    public class PrepareVerificationPhoneNumberCommand : IRequest
    {
        public required string Number { get; set; }
        public required string CheckId { get; set; }
    }
}
