using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PostgreSQLWithEFCore.EntityConfiguration;
using PostgreSQLWithEFCore.EntityContracts;

namespace PostgreSQLWithEFCore.Entities
{

    public class TenantRole : IdentityRole<Guid>, IMultiTenantEntity
    {
        public Guid TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }
    }

    [EntityTypeConfiguration(typeof(UserConfiguration))]
    public class User : IdentityUser<Guid>
    {
        public User()
        {
            Tenants = new HashSet<TenantUser>();
        }

        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public virtual ICollection<TenantUser> Tenants { get; set; }
    }
}
