using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostgreSQLWithEFCore.Entities;

namespace PostgreSQLWithEFCore.EntityConfiguration
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.HasMany(x => x.Jobs)
                   .WithOne(y => y.Tenant)
                   .HasForeignKey(y => y.TenantId);

            builder.HasMany(x => x.Users)
                    .WithOne(x => x.Tenant)
                    .HasForeignKey(x => x.TenantId)
                    .IsRequired(true);
        }
    }
}
