using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Entities.Dish.Commands.Delete
{
    public class DeleteCommandHandler
        (IRestaurantDbContext dbContext)
        :
        IRequestHandler<DeleteCommand>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var entity = await
                _dbContext
                .Dishes
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Domain.Dish), request.Id);

            _dbContext.Dishes.Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
