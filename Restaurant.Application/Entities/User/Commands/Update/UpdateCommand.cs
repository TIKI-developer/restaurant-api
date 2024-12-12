using MediatR;
using Restaurant.Domain;

namespace Restaurant.Application.Entities.User.Commands.Update
{
    public class UpdateCommand : IRequest<Unit>
    {
        public required Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public Address? Address { get; set; }
    }
}
