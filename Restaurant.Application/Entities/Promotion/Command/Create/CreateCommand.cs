using MediatR;

namespace Restaurant.Application.Entities.Promotion.Command.Create
{
    public class CreateCommand : IRequest<Guid>
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Image { get; set; }
        public required bool IsAdvanced { get; set; }
        public required Content.Commands.CreateCommand Content { get; set; }
    }
}
