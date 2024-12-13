using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Dish.Queries.Get
{
    public class GetQueryHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        :
        IRequestHandler<GetQuery, DishList>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<DishList> Handle(GetQuery request, CancellationToken cancellationToken)
        {
            var dishesQuery = await
                _dbContext
                .Dishes
                .ProjectTo<DishLookup>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return new DishList { Dishes = dishesQuery };
        }
    }
}
