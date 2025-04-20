using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Commands
{
    public class DeleteBranchCommandHandler 
        (IRestaurantDbContext dbContext)
        : IRequestHandler<DeleteBranchCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = await
                _dbContext
                .Branches
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Branch), request.Id);

            _dbContext.Branches.Remove(branch);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
