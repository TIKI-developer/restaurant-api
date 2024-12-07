using MediatR;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Promotion;

namespace Restaurant.Application.Entities.Promotion.Command.CreatePromotion
{
    public class CreatePromotionCommandHandler(IRestaurantDbContext dbContext) : IRequestHandler<CreatePromotionCommand, Guid>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<Guid> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
        {
            var promotion = new PromotionModel
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Image = request.Image,
                CreationDateTime = DateTime.UtcNow,
            };

            await _dbContext.Promotions.AddAsync(promotion, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return promotion.Id;
        }
    }
}
