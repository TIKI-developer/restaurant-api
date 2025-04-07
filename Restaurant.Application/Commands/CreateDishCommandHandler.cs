using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.ValueObjects;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Commands
{
    public class CreateDishCommandHandler
        (IRestaurantDbContext dbContext)
        :
        IRequestHandler<CreateDishCommand, Guid>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<Guid> Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            var categories = await
                _dbContext
                .Categories
                .Where(c => request.Categories.Contains(c.Id))
                .ToListAsync(cancellationToken);

            var dish = new Dish
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Image = request.Image,
                Weight = request.Weight,
                Content = new Content
                {
                    IsPublished = request.Content.IsPublished
                },
                Timestamps = new Timestamps
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
