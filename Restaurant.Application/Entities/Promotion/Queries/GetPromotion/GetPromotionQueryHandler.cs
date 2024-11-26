using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Exceptions;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Promotion;

namespace Restaurant.Application.Entities.Promotion.Queries.GetPromotion
{
    public class GetPromotionQueryHandler
        (IRestaurantDbContext dbContext,
        IMapper mapper)
        :
        IRequestHandler<GetPromotionQuery, PromotionDetailsViewModel>
    {
        private readonly IRestaurantDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<PromotionDetailsViewModel> Handle(GetPromotionQuery request, CancellationToken cancellationToken)
        {
            var promotion = await
                _dbContext
                .Promotions
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (promotion == null)
            {
                throw new NotFoundException(nameof(PromotionModel), request.Id);
            }

            return _mapper.Map<PromotionDetailsViewModel>(promotion);
        }
    }
}
