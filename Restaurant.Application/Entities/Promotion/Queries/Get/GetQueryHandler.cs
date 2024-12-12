using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Promotion.Queries.Get
{
    public class GetQueryHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        :
        IRequestHandler<GetQuery, PromotionList>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<PromotionList> Handle(GetQuery request, CancellationToken cancellationToken)
        {
            var promotions = await
                _dbContext
                .Promotions
                .Include(e => e.Content)
                .ProjectTo<PromotionLookup>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PromotionList { Promotions = promotions };
        }
    }
}
