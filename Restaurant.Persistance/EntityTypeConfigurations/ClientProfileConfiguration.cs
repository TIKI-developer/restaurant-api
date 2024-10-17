using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.User.Client;

namespace Restaurant.Persistence.EntityTypeConfigurations
{
    public class ClientProfileConfiguration : IEntityTypeConfiguration<ClientModel.ProfileModel>
    {
        public void Configure(EntityTypeBuilder<ClientModel.ProfileModel> builder) { }
    }
}
