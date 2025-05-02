using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder
                .OwnsOne(e => e.Address, a =>
                {
                    a.WithOwner();
                });

            builder.OwnsOne(b => b.Schedule, scheduleBuilder =>
            {
                scheduleBuilder.WithOwner(); // для owned type

                // DailySchedule как коллекция внутри Schedule
                scheduleBuilder.OwnsMany(s => s.Days, dailyScheduleBuilder =>
                {
                    dailyScheduleBuilder.WithOwner();

                    dailyScheduleBuilder.Property(ds => ds.Day)
                        .HasConversion<int>(); // сохраняем enum как int

                    dailyScheduleBuilder.Property(ds => ds.OpenTime)
                        .HasConversion(
                            v => v.ToTimeSpan(),       // TimeOnly -> TimeSpan
                            v => TimeOnly.FromTimeSpan(v) // TimeSpan -> TimeOnly
                        );

                    dailyScheduleBuilder.Property(ds => ds.CloseTime)
                        .HasConversion(
                            v => v.ToTimeSpan(),
                            v => TimeOnly.FromTimeSpan(v)
                        );

                    dailyScheduleBuilder.Property(ds => ds.IsClosed);

                    // Убираем явную настройку ключа, чтобы не создавать отдельную таблицу для DailySchedule
                    // EF автоматически будет использовать Day как часть ключа Schedule.
                });
            });

            builder
                .OwnsOne(e => e.Content, c =>
                {
                    c.WithOwner();
                });

            builder
                .HasMany(b => b.Orders)
                .WithOne(o => o.Branch);
        }

    }
}
