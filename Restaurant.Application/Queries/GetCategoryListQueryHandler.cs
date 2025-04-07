using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetCategoryListQueryHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        :
        IRequestHandler<GetCategoryListQuery, CategoryList>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<CategoryList> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categoriesQuery = await
                _dbContext
                    .Categories
                    .ProjectTo<CategoryItem>(_mapper.ConfigurationProvider)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

            return new CategoryList { Categories = categoriesQuery };
        }
    }
}
