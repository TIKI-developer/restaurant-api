using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Dish.Queries.GetByCategory
{
    public class GetByCategoryQueryHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        :
        IRequestHandler<GetByCategoryQuery, DishList>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<DishList> Handle(GetByCategoryQuery request, CancellationToken cancellationToken)
        {
            var dishList = await
                _dbContext
                    .Dishes
                    .Include(e => e.Categories)
                    .Include(e => e.Content)
                    .Where(e => e.Categories.Any(c => c.Id == request.CategoryId) && e.Content.IsPublished)
                    .ProjectTo<DishLookup>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
                    ?? throw new NotFoundException(nameof(Domain.Dish), request.CategoryId);
            return new DishList { Dishes = dishList };
        }
    }
}
