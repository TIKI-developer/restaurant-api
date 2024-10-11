using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, CategoryListViewModel>
    {
        private readonly IRestaurantDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCategoryListQueryHandler(IRestaurantDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CategoryListViewModel> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categoriesQuery =
                await _dbContext.Categories
                    .ProjectTo<CategoryLookupDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            return new CategoryListViewModel { Categories = categoriesQuery };
        }
    }
}
