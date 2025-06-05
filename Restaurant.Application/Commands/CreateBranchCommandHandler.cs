using MediatR;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Entities;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Application.Commands
{
    public class CreateBranchCommandHandler 
        (IRestaurantDbContext dbContext)
        : IRequestHandler<CreateBranchCommand, Guid>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<Guid> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            var newBranch = new Branch 
            { 
                Id = Guid.NewGuid(),
                Timestamps = new Timestamps { CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                Address = request.Address,
                Name = request.Name,
                IsActive = request.IsActive,
                PhoneNumber = request.PhoneNumber,
                Schedule = request.Schedule,
                AverageCookingTime = request.AverageCookingTime,
                Content = request.Content
            };

            await _dbContext.Branches.AddAsync(newBranch, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return newBranch.Id;
        }
    }
}
