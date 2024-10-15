using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.User;

namespace Restaurant.Application.Entities.Cart.Queries.GetCartDetails
{
    public class GetCartDetailsQueryHandler(IMapper mapper, IRestaurantDbContext dbContext) : IRequestHandler<GetCartDetailsQuery, CartDetailsViewModel>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<CartDetailsViewModel> Handle(GetCartDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await
                _dbContext
                    .Carts
                    .FirstOrDefaultAsync(e => e.Client.Id == request.ClientId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(UserModel), request.ClientId);
            }

            return _mapper.Map<CartDetailsViewModel>(entity);
        }
    }
}
