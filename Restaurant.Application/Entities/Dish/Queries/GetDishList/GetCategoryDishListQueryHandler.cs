using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Dish;

namespace Restaurant.Application.Entities.Dish.Queries.GetDishList
{
    public class GetCategoryDishListQueryHandler(IRestaurantDbContext dbContext, IMapper mapper) : IRequestHandler<GetCategoryDishListQuery, DishListViewModel>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<DishListViewModel> Handle(GetCategoryDishListQuery request, CancellationToken cancellationToken)
        {
            var dishList = await
                _dbContext
                    .Dishes
                    .Where(d => d.Categories.Any(c => c.Id == request.CategoryId))
                    .ProjectTo<DishLookupDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            if (dishList == null)
            {
                throw new NotFoundException(nameof(DishModel), request.CategoryId);
            }

            return new DishListViewModel { Dishes = dishList };
        }
    }
}
