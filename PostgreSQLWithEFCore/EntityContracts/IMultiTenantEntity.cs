using PostgreSQLWithEFCore.Entities;

namespace PostgreSQLWithEFCore.EntityContracts
{
    public interface IMultiTenantEntity
    {
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
