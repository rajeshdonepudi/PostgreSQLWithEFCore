namespace PostgreSQLWithEFCore.EntityContracts
{
    public interface IActivatable
    {
        bool IsActive { get; set; }
    }
}
