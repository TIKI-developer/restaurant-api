namespace Restaurant.Domain.Entities
{
    public class FncToken
    {
        public required string Value { get; set; }
        public required User User { get; set; }
    }
}
