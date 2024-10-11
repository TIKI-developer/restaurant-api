using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;


namespace Restaurant.Application.Dishes.Queries.GetDishList
{
    public class GetDishListQueryHandler : IRequestHandler<GetDishListQuery, DishListViewModel>
    {
        private readonly IRestaurantDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDishListQueryHandler(IRestaurantDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<DishListViewModel> Handle(GetDishListQuery request, CancellationToken cancellationToken)
        {
            var dishesQuery =
                await _dbContext.Dishes
                .ProjectTo<DishLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new DishListViewModel { Dishes = dishesQuery };
        }
    }
}
