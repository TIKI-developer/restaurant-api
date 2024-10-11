using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain;

namespace Restaurant.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IRestaurantDbContext _dbContext;

        public UpdateCategoryCommandHandler(IRestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Categories.FirstOrDefaultAsync(dish =>
                    dish.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }

            entity.Name = request.Name;
            entity.Image = request.Image;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
