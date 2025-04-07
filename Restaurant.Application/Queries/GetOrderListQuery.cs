using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries
{
    public class GetOrderListQuery : IRequest<OrderList>
    {
        public int? ByLastDays { get; set; }
    }
}
