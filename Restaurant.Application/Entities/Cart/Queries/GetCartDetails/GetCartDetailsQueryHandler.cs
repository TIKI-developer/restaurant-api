using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Cart;


namespace Restaurant.Application.Entities.Cart.Queries.GetCartDetails
{
    public class GetCartDetailsQueryHandler(IMapper mapper, IRestaurantDbContext dbContext) : IRequestHandler<GetCartDetailsQuery, CartDetailsViewModel>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<CartDetailsViewModel> Handle(GetCartDetailsQuery request, CancellationToken cancellationToken)
        {
            var cart = await
                _dbContext
                    .Carts
                    .Include(c => c.Items)
                    .ThenInclude(i => i.Dish)
                    .FirstOrDefaultAsync(e => e.UserId == request.UserId, cancellationToken);

            if (cart == null)
            {
                throw new NotFoundException(nameof(CartModel), request.UserId);
            }

            return _mapper.Map<CartDetailsViewModel>(cart);
        }
    }
}
