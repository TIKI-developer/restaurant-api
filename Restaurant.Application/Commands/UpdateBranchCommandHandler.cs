using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Entities;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Application.Commands
{
    public class UpdateBranchCommandHandler 
        (IRestaurantDbContext dbContext)
        : IRequestHandler<UpdateBranchCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = await
                _dbContext
                .Branches
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Branch), request.Id);

            branch.Name = request.Name ?? branch.Name;
            branch.PhoneNumber = request.PhoneNumber ?? branch.PhoneNumber;
            branch.Address = request.Address ?? branch.Address;
            branch.IsActive = request.IsActive ?? branch.IsActive;
            branch.Schedule = request.Schedule ?? branch.Schedule;
            branch.AverageCookingTime = request.AverageCookingTime ?? branch.AverageCookingTime;
            branch.Content = request.Content ?? branch.Content;


            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
