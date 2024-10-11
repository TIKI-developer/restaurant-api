using MediatR;
using Restaurant.Application.Interfaces;
using Restaurant.Domain;

namespace Restaurant.Application.Categories.Commands.CreateCategory
{
    public class CreateDishCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly IRestaurantDbContext _dbContext;

        public CreateDishCommandHandler(IRestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
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
