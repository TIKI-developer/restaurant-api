using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Order.Queries.GetById
{
    public class GetByIdQueryHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        :
        IRequestHandler<GetByIdQuery, OrderDetails>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<OrderDetails> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await
                _dbContext
                .Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Dish)
                .Include(o => o.User)
                .ThenInclude(u => u.Profile)
                .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Domain.Order), request.Id);

            return _mapper.Map<OrderDetails>(order);
        }
    }
}
