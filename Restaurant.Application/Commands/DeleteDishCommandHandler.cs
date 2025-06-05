using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Commands
{
    public class DeleteDishCommandHandler
        (IRestaurantDbContext dbContext)
        :
        IRequestHandler<DeleteDishCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task Handle(DeleteDishCommand request, CancellationToken cancellationToken)
        {
            var entity = await
                _dbContext
                .Dishes
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Domain.Entities.Dish), request.Id);

            _dbContext.Dishes.Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
