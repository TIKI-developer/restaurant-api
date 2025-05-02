using MediatR;

namespace Restaurant.Application.Commands
{
    public class VerifyNumberCommand : IRequest
    {
        public required string[] Data { get; set; }
        public required string Hash { get; set; }
    }
}
