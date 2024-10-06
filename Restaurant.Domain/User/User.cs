using System.Collections.Generic;

namespace Restaurant.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public List<Order> Orders { get; set; }
    }

}