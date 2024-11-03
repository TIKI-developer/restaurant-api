using MediatR;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Category;

namespace Restaurant.Application.Entities.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler(IRestaurantDbContext dbContext) : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new CategoryModel
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Image = request.Image
            };

            await _dbContext.Categories.AddAsync(category, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return category.Id;
        }
    }
}
