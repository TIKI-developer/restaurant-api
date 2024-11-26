using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;


namespace Restaurant.Application.Entities.Dish.Queries.GetDishList
{
    public class GetDishListQueryHandler(IRestaurantDbContext dbContext, IMapper mapper) : IRequestHandler<GetDishListQuery, DishListViewModel>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<DishListViewModel> Handle(GetDishListQuery request, CancellationToken cancellationToken)
        {
            var dishesQuery = await
                _dbContext
                .Dishes
                .ProjectTo<DishLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new DishListViewModel { Dishes = dishesQuery };
        }
    }
}
