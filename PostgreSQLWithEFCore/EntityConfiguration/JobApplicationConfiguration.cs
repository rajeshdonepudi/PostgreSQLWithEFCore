using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostgreSQLWithEFCore.Entities;

namespace PostgreSQLWithEFCore.EntityConfiguration
{
    public class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
    {
        public void Configure(EntityTypeBuilder<JobApplication> builder)
        {
            builder.HasOne(x => x.Job)
                .WithMany(x => x.JobApplications)
                .HasForeignKey(x => x.JobId);

            builder.HasOne(x => x.Applicant)
                    .WithMany(x => x.AppliedJobs)
                    .HasForeignKey(x => x.ApplicantId);
        }
    }
}
