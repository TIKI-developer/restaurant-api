using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain;

namespace Restaurant.Application.Entities.Promotion.Command.Update
{
    public class UpdateCommandHandler
        (IRestaurantDbContext dbContext,
        INotificationService notificationService)
        :
        IRequestHandler<UpdateCommand, Unit>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly INotificationService _notificationService = notificationService;

        public async Task<Unit> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var users = await
                _dbContext
                .Users
                .Include(e => e.FncTokens)
                .ToListAsync(cancellationToken);

            var promotion = await
                _dbContext
                .Promotions
                .Include(e => e.Content)
                .Include(e => e.Timestamps)
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Domain.Promotion), request.Id);

            promotion.Title = request.Title ?? promotion.Title;
            promotion.Description = request.Description ?? promotion.Description;
            promotion.Image = request.Image ?? promotion.Image;
            promotion.IsAdvanced = request.IsAdvanced ?? promotion.IsAdvanced;
            if (request.Content != null)
            {
                promotion.Content.IsPublished = request.Content.IsPublished ?? promotion.Content.IsPublished;
            }
            promotion.Timestamps.UpdatedAt = DateTime.UtcNow;

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

            return Unit.Value;
        }
    }
}
