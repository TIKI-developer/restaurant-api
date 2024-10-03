using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain;


namespace Restaurant.Application.Dishes.Commands.UpdateDish
{
    public class UpdateDishCommandHandler : IRequestHandler<UpdateDishCommand>
    {
        private readonly IDishDbContext _dbContext;

        public UpdateDishCommandHandler(IDishDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(UpdateDishCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Dishes.FirstOrDefaultAsync(dish =>
                    dish.Id == request.Id, cancellationToken);

            if (entity == null) 
            {
                throw new NotFoundException(nameof(Dish), request.Id);
            }

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Price = request.Price;
            entity.Image = request.Image;
            entity.Categories = request.Categories;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
