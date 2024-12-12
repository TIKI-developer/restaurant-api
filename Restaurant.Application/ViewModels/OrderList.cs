namespace Restaurant.Application.ViewModels
{
    public class OrderList
    {
        public required ICollection<OrderLookup> Orders { get; set; }
    }
}
