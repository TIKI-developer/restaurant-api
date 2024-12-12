using MediatR;

namespace Restaurant.Application.Entities.User.Commands.PrepareVerifyNumber
{
    public class PrepareVerificationPhoneNumberCommand : IRequest
    {
        public required string Number { get; set; }
        public required string CheckId { get; set; }
    }
}
