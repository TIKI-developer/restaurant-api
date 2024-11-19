using Restaurant.Domain.User.Client;

namespace Restaurant.Domain.Order
{
    public class OrderModel
    {
        public required Guid Id { get; set; }
        public required DateTime CreationDateTime { get; set; }
        public required string Address { get; set; }
        public required OrderStatus Status { get; set; }
        public required ClientModel? Client { get; set; }
        public List<OrderItem>? Items { get; set; }
    }
    public enum OrderStatus
    {
        Pending,
        Working,
        Completed,
        Cancelled
    }
}
