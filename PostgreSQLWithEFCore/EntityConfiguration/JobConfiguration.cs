using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostgreSQLWithEFCore.Entities;

namespace PostgreSQLWithEFCore.EntityConfiguration
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasOne(x => x.CreatedBy)
                .WithMany(y => y.CreatedJobs)
                .HasForeignKey(x => x.CreatedById);

            builder.HasMany(x => x.JobApplications)
                   .WithOne(x => x.Job)
                   .HasForeignKey(x => x.JobId);
        }
    }
}
