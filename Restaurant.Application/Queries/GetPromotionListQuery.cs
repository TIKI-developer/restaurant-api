using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetPromotionListQuery : IRequest<PromotionList> { }
}
