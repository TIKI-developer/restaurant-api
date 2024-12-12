using MediatR;

namespace Restaurant.Application.Entities.Promotion.Command.Update
{
    public class UpdateCommand : IRequest<Unit>
    {
        public required Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool? IsAdvanced { get; set; }
        public Content.Commands.UpdateCommand? Content { get; set; }
        public string? Image { get; set; }
    }
}
