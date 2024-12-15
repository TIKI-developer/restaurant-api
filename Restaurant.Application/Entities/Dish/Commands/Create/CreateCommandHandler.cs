using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Entities.Dish.Commands.Create
{
    public class CreateCommandHandler
        (IRestaurantDbContext dbContext)
        :
        IRequestHandler<CreateCommand, Guid>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<Guid> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var categories = await
                _dbContext
                .Categories
                .Where(c => request.Categories.Contains(c.Id))
                .ToListAsync(cancellationToken);

            var dish = new Domain.Dish
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Image = request.Image,
                Weight = request.Weight,
                Content = new Domain.Content
                { 
                    IsPublished = request.Content.IsPublished
                },
                Timestamps = new Domain.Timestamps
                {
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                Categories = categories
            };

            await _dbContext.Dishes.AddAsync(dish, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return dish.Id;
        }
    }
}
