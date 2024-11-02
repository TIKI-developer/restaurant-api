using Restaurant.Domain;


namespace Restaurant.Application.Entities.Order.Queries.GetOrderList
{
    public class OrderListViewModel
    {
        public required ICollection<OrderLookupDto> Orders { get; set; }
    }
}
