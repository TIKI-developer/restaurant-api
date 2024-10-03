using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Interfaces;
using Restaurant.Domain;
using Restaurant.Persistence.EntityTypeConfigurations;


namespace Restaurant.Persistence
{
    public class DishDbContext : DbContext, IDishDbContext
    {
        public DbSet<Dish> Dishes { get; set; }

        public DishDbContext(DbContextOptions<DishDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DishConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
