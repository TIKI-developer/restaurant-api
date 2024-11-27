using MediatR;

namespace Restaurant.Application.Entities.User.Commands.VerifyNumber
{
    public class PrepareVerifyNumberCommand : IRequest
    {
        public required string Number { get; set; }
        public required string CheckId { get; set; }
    }
}
