using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Dish.Queries.GetPublished
{
    public class GetPublishedQueryHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        :
        IRequestHandler<GetPublishedQuery, DishList>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<DishList> Handle(GetPublishedQuery request, CancellationToken cancellationToken)
        {
            var dishesQuery = await
                _dbContext
                .Dishes
                .Include(e => e.Content)
                .Where(e => e.Content.IsPublished == true)
                .ProjectTo<DishLookup>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return new DishList { Dishes = dishesQuery };
        }
    }
}
