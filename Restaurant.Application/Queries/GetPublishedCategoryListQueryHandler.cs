using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetPublishedCategoryListQueryHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        :
        IRequestHandler<GetPublishedCategoryListQuery, CategoryList>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<CategoryList> Handle(GetPublishedCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categoriesQuery = await
                _dbContext
                    .Categories
                    .Include(e => e.Content)
                    .Include(e => e.Timestamps)
                    .OrderBy(e => e.Timestamps.UpdatedAt)
                    .Where(e => e.Content.IsPublished == true)
                    .ProjectTo<CategoryItem>(_mapper.ConfigurationProvider)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

            return new CategoryList { Categories = categoriesQuery };
        }
    }
}
