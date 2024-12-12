using MediatR;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Entities.Promotion.Command.Create
{
    public class CreateCommandHandler
        (IRestaurantDbContext dbContext)
        :
        IRequestHandler<CreateCommand, Guid>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<Guid> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var promotion = new Domain.Promotion
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Image = request.Image,
                IsAdvanced = request.IsAdvanced,
                Content = new Domain.Content
                {
                    IsPublished = false
                },
                Timestamps = new Domain.Timestamps
                {
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            await _dbContext.Promotions.AddAsync(promotion, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return promotion.Id;
        }
    }
}
