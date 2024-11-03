using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Dish;


namespace Restaurant.Application.Entities.Dish.Commands.UpdateDish
{
    public class UpdateDishCommandHandler(IRestaurantDbContext dbContext) : IRequestHandler<UpdateDishCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task Handle(UpdateDishCommand request, CancellationToken cancellationToken)
        {
            var entity = await 
                _dbContext
                .Dishes
                .FirstOrDefaultAsync(dish =>
                    dish.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(DishModel), request.Id);
            }

            var categoryEntities = await 
                _dbContext
                    .Categories
                    .Where(c => request.Categories.Contains(c.Id))
                    .ToListAsync(cancellationToken);

            entity.Name = request.Name ?? entity.Name;
            entity.Description = request.Description ?? entity.Description;
            entity.Price = request.Price ?? entity.Price;
            entity.Images = request.Images ?? entity.Images;
            entity.Categories = categoryEntities;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
