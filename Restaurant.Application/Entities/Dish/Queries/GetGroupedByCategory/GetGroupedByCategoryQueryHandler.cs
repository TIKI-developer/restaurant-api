using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Dish.Queries.GetGroupedByCategory
{
    public class GetGroupedByCategoryQueryHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        : IRequestHandler<GetGroupedByCategoryQuery, DishListGroupedByCategory>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<DishListGroupedByCategory> Handle(GetGroupedByCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await 
                _dbContext
                .Categories
                .Where(e => e.Content.IsPublished == true)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            var vm = new DishListGroupedByCategory();

            foreach (var category in categories)
            {
                var categoryDishes = await _dbContext.Dishes
                     .Where(d => d.Categories.Any(c => c.Id == category.Id))
                     .ProjectTo<DishLookup>(_mapper.ConfigurationProvider)
                     .AsNoTracking()
                     .ToListAsync();
                vm.CategoriesDishes.Add(category.Id, categoryDishes);
            }

            return vm;
        }
    }
}
