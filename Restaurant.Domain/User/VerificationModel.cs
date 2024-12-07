namespace Restaurant.Domain.User
{
    public class VerificationModel
    {
        public required string Number { get; set; }
        public string? CheckId { get; set;}
        public required bool CanLogin { get; set;}
    }
}
