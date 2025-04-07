using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Entities.Promotion.Command.Delete
{
    public class DeleteCommandHandler
        (IRestaurantDbContext dbContext)
        :
        IRequestHandler<DeleteCommand, Unit>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var promotion = await
                _dbContext
                .Promotions
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Domain.Entities.Promotion), request.Id);

            _dbContext.Promotions.Remove(promotion);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
