using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Category;

namespace Restaurant.Application.Entities.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler(IRestaurantDbContext dbContext) : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await 
                _dbContext
                    .Categories
                    .FirstOrDefaultAsync(dish =>
                    dish.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CategoryModel), request.Id);
            }

            entity.Name = request.Name ?? entity.Name;
            entity.Image = request.Image ?? entity.Image;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
