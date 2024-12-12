using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Entities.Category.Commands.Update
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
                    .Categories
                    .Include(e => e.Content)
                    .Include(e => e.Timestamps)
                    .FirstOrDefaultAsync(dish =>
                    dish.Id == request.Id, cancellationToken)
                    ?? throw new NotFoundException(nameof(Domain.Category), request.Id);

            entity.Name = request.Name ?? entity.Name;
            entity.Image = request.Image ?? entity.Image;

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
