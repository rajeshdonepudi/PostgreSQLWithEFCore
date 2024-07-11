using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostgreSQLWithEFCore.Entities;

namespace PostgreSQLWithEFCore.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(x => x.Tenants)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}
