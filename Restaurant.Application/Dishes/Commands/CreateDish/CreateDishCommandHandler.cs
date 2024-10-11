using MediatR;
using Restaurant.Application.Interfaces;
using Restaurant.Domain;
using System.Diagnostics;

namespace Restaurant.Application.Dishes.Commands.CreateDish
{
    public class CreateDishCommandHandler : IRequestHandler<CreateDishCommand, Guid>
    {
        private readonly IRestaurantDbContext _dbContext;

        public CreateDishCommandHandler(IRestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            var dish = new Dish
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
