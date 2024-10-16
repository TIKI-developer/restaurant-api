using Restaurant.Domain.Order;

namespace Restaurant.Domain.User
{
    public abstract class UserModel
    {
        public Guid Id { get; set; }
        public required string Number { get; set; }
        public required string PasswordHash { get; set; }
        public abstract UserRole Role { get; }
    }

}