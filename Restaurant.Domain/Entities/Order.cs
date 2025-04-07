namespace Restaurant.Domain.Entities
{
    public class Order : Entity
    {
        public required string Code { get; set; }
        public Address? Address { get; set; }
        public required OrderStatus Status { get; set; }
        public required int PersonQuantity { get; set; }
        public required bool AddForks { get; set; }
        public required bool AddChopsticks { get; set; }
        public float? DeliveryCost { get; set; }
        public required ReceiptMethod ReceiptMethod { get; set; }
        public required PaymentMethod PaymentMethod { get; set; }
        public required float Cost { get; set; }
        public string? Comment { get; set; }
        public required DateTime ReceiptAt { get; set; }
        public required User User { get; set; }
        public List<OrderDishItem> Items { get; set; } = [];
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
    public enum ReceiptMethod
    {
        Delivery,
        SelfPickup
    }
}
