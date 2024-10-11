namespace Restaurant.Domain
{
	public class Category
	{
		public Guid Id { get; set; }
		public string? Name { get; set; }
		public byte[]? Image { get; set; }
        public ICollection<Dish>? Dishes { get; set; }
    } 
}
