using MediatR;

namespace Restaurant.Application.Commands
{
    public class CreatePromotionCommand : IRequest<Guid>
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Image { get; set; }
        public required bool IsAdvanced { get; set; }
        public required CreateContentCommand Content { get; set; }
    }
}
