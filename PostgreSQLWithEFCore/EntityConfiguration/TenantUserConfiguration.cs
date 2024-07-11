using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostgreSQLWithEFCore.Entities;

namespace PostgreSQLWithEFCore.EntityConfiguration
{
    public class TenantUserConfiguration : IEntityTypeConfiguration<TenantUser>
    {
        public void Configure(EntityTypeBuilder<TenantUser> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany(x => x.Tenants)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Tenant)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.TenantId);

            builder.HasMany(x => x.CreatedJobs)
                .WithOne(x => x.CreatedBy)
                .HasForeignKey(X => X.CreatedById);

            builder.HasMany(x => x.AppliedJobs)
                .WithOne(x => x.Applicant)
                .HasForeignKey(x => x.ApplicantId);
        }
    }
}
