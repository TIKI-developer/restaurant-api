namespace Restaurant.Domain.User
{
    public abstract class UserModel
    {
        public Guid Id { get; set; }
        public required string Number { get; set; }
        public required string PasswordHash { get; set; }
        public string Role { get => InitRole.ToString(); }
        protected abstract UserRole InitRole { get; }
    }
    public enum UserRole
    {
        Client,
        Admin
    }
}