using System.Collections.Generic;

namespace Restaurant.Domain
{
	public class Dish
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public float Price { get; set; }
		public byte[] Image { get; set; }
		public List<Category> Categories { get; set; }
	} 
}