using Restaurant.Domain.User;

namespace Restaurant.Domain.Order
{
    public class OrderModel
    {
        public required Guid Id { get; set; }
        public required DateTime CreationDateTime { get; set; }
        public required string Code { get; set; }
        public required string Address { get; set; }
        public required OrderStatus Status { get; set; }
        public required int PersonQuantity { get; set; }
        public bool AddForks { get; set; }
        public bool AddChopsticks { get; set; }
        public required float Cost { get; set; }
        public required UserModel User { get; set; }
        public List<OrderItem> Items { get; set; } = [];
    }
    public enum OrderStatus
    {
        Pending,
        Adopted,
        Working,
        Delivering,
        Completed,
        Rejected
    }
}
