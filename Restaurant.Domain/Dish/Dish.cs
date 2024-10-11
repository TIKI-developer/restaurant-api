namespace Restaurant.Domain
{
	public class Dish
	{
		public Guid Id { get; set; }
		public required string Name { get; set; }
		public string? Description { get; set; }
		public required float Price { get; set; }
		public byte[]? Image { get; set; }
		public ICollection<Category>? Categories { get; set; }
	} 
}