using MediatR;

namespace Restaurant.Application.Commands
{
    public class CodeCallCommand : IRequest
    {
        public required string PhoneNumber { get; set; }
        public required string Code { get; set; }
        public required string CallId { get; set; }
    }
}
