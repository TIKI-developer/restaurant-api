using MediatR;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Dish;

namespace Restaurant.Application.Entities.Dish.Commands.CreateDish
{
    public class CreateDishCommandHandler(IRestaurantDbContext dbContext) : IRequestHandler<CreateDishCommand, Guid>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<Guid> Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            var dish = new DishModel
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Image = request.Image,
                Categories = request.Categories
            };

            await _dbContext.Dishes.AddAsync(dish, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return dish.Id;
        }
    }
}
