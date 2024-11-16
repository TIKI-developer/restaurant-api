using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Entities.Promotion.Queries.GetPromotionList
{
    public class GetPromotionListQueryHandler(IRestaurantDbContext dbContext, IMapper mapper) : IRequestHandler<GetPromotionListQuery, PromotionListViewModel>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<PromotionListViewModel> Handle(GetPromotionListQuery request, CancellationToken cancellationToken)
        {
            var promotions = await
                _dbContext
                .Promotions
                .ProjectTo<PromotionLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PromotionListViewModel { Promotions = promotions };
        }
    }
}
