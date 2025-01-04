using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Entities.Order.Queries.Get
{
    public class GetQuery : IRequest<OrderList> 
    {
        public int? ByLastDays { get; set; }
    }
}
