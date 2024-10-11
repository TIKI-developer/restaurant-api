using MediatR;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain;

namespace Restaurant.Application.Categories.Commands.DeleteCategory
{
    internal class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IRestaurantDbContext _dbContext;

        public DeleteCategoryCommandHandler(IRestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = 
                await _dbContext.Categories
                .FindAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }

            _dbContext.Categories.Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
