using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Dish;

namespace Restaurant.Application.Entities.Dish.Commands.CreateDish
{
    public class CreateDishCommandHandler(IRestaurantDbContext dbContext) : IRequestHandler<CreateDishCommand, Guid>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<Guid> Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            var categoryEntites = await
                _dbContext
                    .Categories
                    .Where(c => request.Categories.Contains(c.Id))
                    .ToListAsync();

            var dish = new DishModel
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Images = request.Images,
                Categories = categoryEntites
            };

            await _dbContext.Dishes.AddAsync(dish, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return dish.Id;
        }
    }
}
