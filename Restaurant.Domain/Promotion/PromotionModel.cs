namespace Restaurant.Domain.Promotion
{
    public class PromotionModel
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public required DateTime CreationDateTime { get; set; }
    }
}
