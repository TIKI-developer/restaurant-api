using MediatR;

namespace Restaurant.Application.Entities.User.Commands.VerifyNumber
{
    public class VerifyNumberCommand : IRequest
    {
        public required string[] Data { get; set; }
    }
}
