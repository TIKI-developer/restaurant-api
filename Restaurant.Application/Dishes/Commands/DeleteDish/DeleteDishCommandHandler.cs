using MediatR;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain;

namespace Restaurant.Application.Dishes.Commands.DeleteDish
{
    public class DeleteDishCommandHandler : IRequestHandler<DeleteDishCommand>
    {
        private readonly IDishDbContext _dbContext;

        public DeleteDishCommandHandler(IDishDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DeleteDishCommand request, CancellationToken cancellationToken)
        {
            var entity = 
                await _dbContext.Dishes
                .FindAsync([request.Id], cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Dish), request.Id);
            }

            _dbContext.Dishes.Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
