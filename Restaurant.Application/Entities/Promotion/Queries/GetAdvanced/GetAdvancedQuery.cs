using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Promotion.Queries.GetAdvanced
{
    public class GetAdvancedQuery : IRequest<PromotionList> { }
}
