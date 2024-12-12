using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Category.Queries.Get
{
    public class GetQueryHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        :
        IRequestHandler<GetQuery, CategoryList>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<CategoryList> Handle(GetQuery request, CancellationToken cancellationToken)
        {
            var categoriesQuery = await
                _dbContext
                    .Categories
                    .ProjectTo<CategoryLookup>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            return new CategoryList { Categories = categoriesQuery };
        }
    }
}
