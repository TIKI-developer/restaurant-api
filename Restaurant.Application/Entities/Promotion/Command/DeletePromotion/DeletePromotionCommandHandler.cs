using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Promotion;

namespace Restaurant.Application.Entities.Promotion.Command.DeletePromotion
{
    public class DeletePromotionCommandHandler(IRestaurantDbContext dbContext) : IRequestHandler<DeletePromotionCommand, Unit>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(DeletePromotionCommand request, CancellationToken cancellationToken)
        {
            var promotion = await
                _dbContext
                    .Promotions
                    .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken)
                    ?? throw new NotFoundException(nameof(PromotionModel), request.Id);

            _dbContext.Promotions.Remove(promotion);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
