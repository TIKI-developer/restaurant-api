namespace Restaurant.Domain
{
    public class Verification
    {
        public required string Number { get; set; }

        public string? CheckId { get; set; }
        public required bool CanLogin { get; set; }

        public string? CallId { get; set; }
        public string? CallCode { get; set; }
        public required Timestamps Timestamps { get; set; }
    }
}
