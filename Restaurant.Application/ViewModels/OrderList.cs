namespace Restaurant.Application.ViewModels
{
    public class OrderList
    {
        public required ICollection<OrderItem> Orders { get; set; }
    }
}
