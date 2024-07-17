using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PostgreSQLWithEFCore.Entities;

namespace PostgreSQLWithEFCore
{
    public class DatabaseContext : IdentityDbContext<User, TenantRole, Guid>
    {
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<TenantUser> TenantUsers { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }
    }
}
