using MediatR;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Entities;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Application.Commands
{
    public class CreateCategoryCommandHandler
        (IRestaurantDbContext dbContext)
        :
        IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Image = request.Image,
                Content = new Content
                {
                    IsPublished = request.Content.IsPublished
                },
                Timestamps = new Timestamps
                {
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            await _dbContext.Categories.AddAsync(category, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return category.Id;
        }
    }
}
