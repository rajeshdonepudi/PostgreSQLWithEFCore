using Microsoft.EntityFrameworkCore;
using PostgreSQLWithEFCore.EntityConfiguration;
using PostgreSQLWithEFCore.EntityContracts;

namespace PostgreSQLWithEFCore.Entities
{
    [EntityTypeConfiguration(typeof(TenantConfiguration))]
    public class Tenant : BaseEntity<Guid>, IActivatable, ISoftDeletable
    {
        public Tenant()
        {
            Users = new HashSet<TenantUser>();
            Jobs = new HashSet<Job>();
        }

        public required string Name { get; set; }
        public required string Host { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<TenantUser> Users { get; set; }
    }
}
