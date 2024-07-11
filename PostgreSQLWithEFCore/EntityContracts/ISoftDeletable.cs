namespace PostgreSQLWithEFCore.EntityContracts
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
    }
}
