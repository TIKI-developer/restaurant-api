namespace Restaurant.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public required string Number { get; set; }
        public required string PasswordHash { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }

}