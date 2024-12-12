using MediatR;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Entities.Category.Commands.Create
{
    public class CreateCommandHandler
        (IRestaurantDbContext dbContext)
        :
        IRequestHandler<CreateCommand, Guid>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<Guid> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var category = new Domain.Category
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Image = request.Image,
                Content = new Domain.Content
                {
                    IsPublished = false
                },
                Timestamps = new Domain.Timestamps
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
