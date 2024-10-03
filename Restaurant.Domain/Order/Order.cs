using System;
using System.Collections.Generic;

namespace Restaurant.Domain
{
    public class Order
    {
        public string Id { get; set; }
        public List<Dish> Products { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
