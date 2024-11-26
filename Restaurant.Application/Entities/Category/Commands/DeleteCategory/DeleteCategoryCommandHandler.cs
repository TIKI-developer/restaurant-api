using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Category;

namespace Restaurant.Application.Entities.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler(IRestaurantDbContext dbContext) : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await
                _dbContext
                    .Categories
                    .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CategoryModel), request.Id);
            }

            _dbContext.Categories.Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
