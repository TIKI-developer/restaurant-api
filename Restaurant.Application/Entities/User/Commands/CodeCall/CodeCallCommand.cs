using MediatR;

namespace Restaurant.Application.Entities.User.Commands.CodeCall
{
    public class CodeCallCommand : IRequest
    {
        public required string PhoneNumber { get; set; }
        public required string Code { get; set; }
        public required string CallId { get; set; }
    }
}
