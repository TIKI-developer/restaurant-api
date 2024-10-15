using Restaurant.Domain;


namespace Restaurant.Application.Entities.Order.Queries.GetClientOrderList
{
    public class OrderListViewModel
    {
        public required ICollection<OrderLookupDto> Orders { get; set; }
    }
}
