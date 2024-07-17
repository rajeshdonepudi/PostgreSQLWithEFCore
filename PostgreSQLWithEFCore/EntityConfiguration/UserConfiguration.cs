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

            builder.OwnsOne(c => c.Address, d =>
             {
                 d.ToJson();
             });

            builder.Property(x => x.Tags).HasColumnType("text[]");

            builder.HasGeneratedTsVectorColumn(u => u.SearchVector, "english", u => new
            {
                u.Description,
                u.Metadata
            }).HasIndex(p => p.SearchVector).HasMethod("GIN");
        }
    }
}
