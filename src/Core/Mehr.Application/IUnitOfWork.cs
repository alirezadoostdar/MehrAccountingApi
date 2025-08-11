namespace Mehr.Application;

public interface IUnitOfWork
{
    void SaveChange();
    Task SaveChangesAsync();
    void Begin();
    Task BeginAsync();
    void Commit();
    Task CommitAsync();
    void Rollback();
    Task RollbackAsync();
}
