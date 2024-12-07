using MediatR;

namespace Restaurant.Application.Entities.Promotion.Command.UpdatePromotion
{
    public class UpdatePromotionCommand : IRequest<Unit>
    {
        public required Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
    }
}
