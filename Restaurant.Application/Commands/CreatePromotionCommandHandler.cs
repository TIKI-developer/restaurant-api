using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Entities;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Application.Commands
{
    public class CreatePromotionCommandHandler
        (IRestaurantDbContext dbContext,
        INotificationService notificationService)
        :
        IRequestHandler<CreatePromotionCommand, Guid>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly INotificationService _notificationService = notificationService;

        public async Task<Guid> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
        {
            var users = await
                _dbContext
                .Users
                .Include(e => e.FncTokens)
                .ToListAsync(cancellationToken);

            var promotion = new Promotion
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Image = request.Image,
                IsAdvanced = request.IsAdvanced,
                Content = new Content
                {
                    IsPublished = request.Content.IsPublished,
                },
                Timestamps = new Timestamps
                {
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            await _dbContext.Promotions.AddAsync(promotion, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            if (promotion.Content.IsPublished)
            {
                foreach (var user in users)
                {
                    foreach (var token in user.FncTokens)
                    {
                        await _notificationService.Send($"Новая акция! {promotion.Title}", $"{promotion.Description}", token.Value);
                    }
                }
            }
            return promotion.Id;
        }
    }
}
