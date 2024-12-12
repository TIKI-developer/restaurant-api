using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Promotion.Queries.Get
{
    public class GetQuery : IRequest<PromotionList> { }
}
