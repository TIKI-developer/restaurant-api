using MediatR;

namespace Restaurant.Application.Entities.Promotion.Command.DeletePromotion
{
    public class DeletePromotionCommand : IRequest<Unit>
    {
        public required Guid Id { get; set; }
    }
}
