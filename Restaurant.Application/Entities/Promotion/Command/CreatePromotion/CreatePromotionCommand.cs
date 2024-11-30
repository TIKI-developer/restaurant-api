using MediatR;

namespace Restaurant.Application.Entities.Promotion.Command.CreatePromotion
{
    public class CreatePromotionCommand : IRequest<Guid>
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Image { get; set; }
    }
}
