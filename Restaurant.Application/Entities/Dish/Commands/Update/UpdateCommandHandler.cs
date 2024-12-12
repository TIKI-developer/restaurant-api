using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Entities.Dish.Commands.Update
{
    public class UpdateCommandHandler
        (IRestaurantDbContext dbContext)
        :
        IRequestHandler<UpdateCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = await
                _dbContext
                .Dishes
                .Include(e => e.Content)
                .Include(e => e.Timestamps)
                .FirstOrDefaultAsync(dish => dish.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Domain.Dish), request.Id);

            var categoryEntities = await
                _dbContext
                .Categories
                .Include(e => e.Content)
                .Include(e => e.Timestamps)
                .Where(c => request.Categories.Contains(c.Id))
                .ToListAsync(cancellationToken);

            entity.Name = request.Name ?? entity.Name;
            entity.Description = request.Description ?? entity.Description;
            entity.Price = request.Price ?? entity.Price;
            entity.Image = request.Image ?? entity.Image;
            entity.Categories = categoryEntities ?? entity.Categories;
            if (request.Content != null)
            {
                entity.Content.IsPublished = request.Content.IsPublished ?? entity.Content.IsPublished;
            }
            entity.Timestamps.UpdatedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
