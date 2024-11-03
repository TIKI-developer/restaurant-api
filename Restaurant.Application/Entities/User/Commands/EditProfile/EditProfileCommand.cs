using MediatR;

namespace Restaurant.Application.Entities.User.Commands.EditProfile
{
    public class EditProfileCommand : IRequest<Unit>
    {
        public required Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public string? Address { get; set; }
    }
}
