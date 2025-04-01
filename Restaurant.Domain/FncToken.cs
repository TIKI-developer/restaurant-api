namespace Restaurant.Domain
{
    public class FncToken
    {
        public required string Value { get; set; }
        public required User User { get; set; }
    }
}
