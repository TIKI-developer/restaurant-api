using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Promotion.Queries.GetPublished
{
    public class GetPublishedQuery : IRequest<PromotionList> { }
}
