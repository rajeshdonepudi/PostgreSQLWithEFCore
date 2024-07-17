using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;
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
        public Address Address { get; set; }
        public string[] Tags { get; set; }
        public string Description { get; set; }
        public string Metadata { get; set; }
        public NpgsqlTsVector SearchVector { get; set; }
    }

    public class Address
    {
        public string City { get; set; }
    }
}
