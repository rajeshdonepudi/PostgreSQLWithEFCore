using Microsoft.EntityFrameworkCore;
using PostgreSQLWithEFCore.EntityConfiguration;
using PostgreSQLWithEFCore.EntityContracts;

namespace PostgreSQLWithEFCore.Entities
{
    [EntityTypeConfiguration(typeof(JobApplicationConfiguration))]
    public class JobApplication : BaseEntity<Guid>, ISoftDeletable, IActivatable
    {
        public DateTime StartedDate { get; set; }
        public DateTime? SubmittedDate { get; set; }

        public Guid JobId { get; set; }
        public virtual Job Job { get; set; }

        public Guid ApplicantId  { get; set; }
        public virtual TenantUser Applicant { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
