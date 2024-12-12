using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Entities.Promotion.Command.Update
{
    public class UpdateCommandHandler
        (IRestaurantDbContext dbContext)
        :
        IRequestHandler<UpdateCommand, Unit>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = await
                _dbContext
                .Promotions
                .Include(e => e.Content)
                .Include(e => e.Timestamps)
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Domain.Promotion), request.Id);

            entity.Title = request.Title ?? entity.Title;
            entity.Description = request.Description ?? entity.Description;
            entity.Image = request.Image ?? entity.Image;
            entity.IsAdvanced = request.IsAdvanced ?? entity.IsAdvanced;
            if (request.Content != null)
            {
                entity.Content.IsPublished = request.Content.IsPublished ?? entity.Content.IsPublished;
            }
            entity.Timestamps.UpdatedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
