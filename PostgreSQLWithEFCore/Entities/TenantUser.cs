using Microsoft.EntityFrameworkCore;
using PostgreSQLWithEFCore.EntityConfiguration;

namespace PostgreSQLWithEFCore.Entities
{
    [EntityTypeConfiguration(typeof(TenantUserConfiguration))]
    public class TenantUser : BaseEntity<Guid>
    {
        public TenantUser()
        {
            AppliedJobs = new HashSet<JobApplication>();
        }

        public Guid TenantId { get; set; }
        public Guid UserId { get; set; }

        public virtual Tenant Tenant { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<JobApplication> AppliedJobs { get; set; }
        public virtual ICollection<Job> CreatedJobs { get; set; }
    }
}
