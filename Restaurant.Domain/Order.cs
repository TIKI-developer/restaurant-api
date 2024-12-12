namespace Restaurant.Domain
{
    public class Order : Entity
    {
        public required string Code { get; set; }
        public required Address Address { get; set; }
        public required OrderStatus Status { get; set; }
        public required int PersonQuantity { get; set; }
        public required bool AddForks { get; set; }
        public required bool AddChopsticks { get; set; }
        public required PaymentMethod PaymentMethod { get; set; }
        public required float Cost { get; set; }
        public required User User { get; set; }
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
    public enum PaymentMethod
    {
        Cash,
        Card
    }
}
