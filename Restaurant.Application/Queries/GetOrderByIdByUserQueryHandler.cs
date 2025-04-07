using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetOrderByIdByUserQueryHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        :
        IRequestHandler<GetOrderByIdByUserQuery, OrderDetails>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<OrderDetails> Handle(GetOrderByIdByUserQuery request, CancellationToken cancellationToken)
        {
            var order = await
                _dbContext
                .Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Dish)
                .Include(o => o.User)
                .ThenInclude(u => u.Profile)
                .Where(o => o.User.Id == request.UserId)
                .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Domain.Entities.Order), request.Id);

            return _mapper.Map<OrderDetails>(order);
        }
    }
}
