using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Promotion;

namespace Restaurant.Application.Entities.Promotion.Command.UpdatePromotion
{
    public class UpdatePromotionCommandHandler(IRestaurantDbContext dbContext) : IRequestHandler<UpdatePromotionCommand, Unit>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(UpdatePromotionCommand request, CancellationToken cancellationToken)
        {
            var promotion = await
                _dbContext
                .Promotions
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(PromotionModel), request.Id);

            promotion.Title = request.Title ?? promotion.Title;
            promotion.Description = request.Description ?? promotion.Description;
            promotion.Image = request.Image ?? promotion.Image;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
