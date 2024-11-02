using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Entities.Category.Queries.GetCategoryList
{
    public class GetCategoryListQueryHandler(IRestaurantDbContext dbContext, IMapper mapper) : IRequestHandler<GetCategoryListQuery, CategoryListViewModel>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<CategoryListViewModel> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categoriesQuery = await 
                _dbContext
                    .Categories
                    .ProjectTo<CategoryLookupDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            return new CategoryListViewModel { Categories = categoriesQuery };
        }
    }
}
