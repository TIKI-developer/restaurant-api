using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetDishListByCategoryQueryHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        :
        IRequestHandler<GetDishListByCategoryQuery, DishList>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<DishList> Handle(GetDishListByCategoryQuery request, CancellationToken cancellationToken)
        {
            var dishList = await
                _dbContext
                    .Dishes
                    .Include(e => e.Categories)
                    .Include(e => e.Content)
                    .Where(e => e.Categories.Any(c => c.Id == request.CategoryId) && e.Content.IsPublished)
                    .ProjectTo<DishItem>(_mapper.ConfigurationProvider)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken)
                    ?? throw new NotFoundException(nameof(Domain.Entities.Dish), request.CategoryId);
            return new DishList { Dishes = dishList };
        }
    }
}
