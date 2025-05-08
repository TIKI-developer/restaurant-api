using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Commands
{
    public class UpdateDishCommandHandler
        (IRestaurantDbContext dbContext)
        :
        IRequestHandler<UpdateDishCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task Handle(UpdateDishCommand request, CancellationToken cancellationToken)
        {
            var dish = await
                _dbContext
                .Dishes
                .Include(e => e.Content)
                .Include(e => e.Timestamps)
                .Include(e => e.Categories)
                .FirstOrDefaultAsync(dish => dish.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Domain.Entities.Dish), request.Id);

            var categories = await
                _dbContext
                .Categories
                .Include(e => e.Content)
                .Include(e => e.Timestamps)
                .Where(c => request.Categories.Contains(c.Id))
                .ToListAsync(cancellationToken) ?? [];

            dish.Name = request.Name ?? dish.Name;
            dish.Description = request.Description ?? dish.Description;
            dish.Price = request.Price ?? dish.Price;
            dish.Image = request.Image ?? dish.Image;
            dish.Weight = request.Weight ?? dish.Weight;
            dish.Categories = categories ?? dish.Categories;
            if (request.Content != null)
            {
                dish.Content.IsPublished = request.Content.IsPublished ?? dish.Content.IsPublished;

                var cartsWithDish = await _dbContext.Carts
                    .Include(c => c.Items)
                    .Where(c => c.Items.Any(i => i.DishId == dish.Id))
                    .ToListAsync(cancellationToken);

                foreach (var cart in cartsWithDish)
                {
                    cart.Items.RemoveAll(i => i.DishId == dish.Id);
                }
            }
            dish.Timestamps.UpdatedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
