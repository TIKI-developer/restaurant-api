namespace Restaurant.Domain.Promotion
{
    public class PromotionModel
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Image { get; set; }
        public required DateTime CreationDateTime { get; set; }
    }
}
