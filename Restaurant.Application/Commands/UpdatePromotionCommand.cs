using MediatR;

namespace Restaurant.Application.Commands
{
    public class UpdatePromotionCommand : IRequest<Unit>
    {
        public required Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool? IsAdvanced { get; set; }
        public UpdateContentCommand? Content { get; set; }
        public string? Image { get; set; }
    }
}
