using MediatR;

namespace Restaurant.Application.Entities.Promotion.Command.CreatePromotion
{
    public class CreatePromotionCommand : IRequest<Guid>
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
    }
}
