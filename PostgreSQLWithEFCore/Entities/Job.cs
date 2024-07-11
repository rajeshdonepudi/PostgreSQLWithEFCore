using Microsoft.EntityFrameworkCore;
using PostgreSQLWithEFCore.EntityConfiguration;
using PostgreSQLWithEFCore.EntityContracts;

namespace PostgreSQLWithEFCore.Entities
{
    [EntityTypeConfiguration(typeof(JobConfiguration))]
    public class Job : BaseEntity<Guid>, ISoftDeletable, IActivatable, ICloneable
    {
        public Job()
        {
            JobApplications = new HashSet<JobApplication>();
        }

        public required string Description { get; set; }
        public required string Title { get; set; }
        public bool IsDeleted { get ; set ; }
        public bool IsActive { get ; set ; }

        public Guid CreatedById { get; set; }
        public virtual TenantUser CreatedBy { get; set; }
        public virtual ICollection<JobApplication> JobApplications { get; set; }

        public Guid TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }

        public object Clone()
        {
            return new Job
            {
                Title = Title,
                Description = Description,
            };
        }
    }
}
