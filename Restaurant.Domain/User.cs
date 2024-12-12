namespace Restaurant.Domain
{
    public abstract class User : Entity
    {
        public required string PhoneNumber { get; set; }
        public required UserProfile Profile { get; set; }
        public abstract List<UserPermission> Permissions { get; }
        public Cart? Cart { get; set; }
        public List<Order>? Orders { get; set; } = [];
    }
    public class UserProfile
    {
        public string? Name { get; set; }
        public Address? Address { get; set; }
    }
    public enum UserPermission
    {
        Client,
        Admin
    }
}