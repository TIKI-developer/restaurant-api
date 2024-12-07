using MediatR;

namespace Restaurant.Application.Entities.Promotion.Queries.GetPromotion
{
    public class GetPromotionQuery : IRequest<PromotionDetailsViewModel>
    {
        public required Guid Id { get; set; }
    }
}
