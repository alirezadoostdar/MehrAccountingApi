namespace Mehr.Application;

public interface IUnitOfWork
{
    void SaveChange();
    Task SaveChangesAsync(CancellationToken cancellationToken);
    void Begin();
    Task BeginAsync(CancellationToken cancellationToken);
    void Commit();
    Task CommitAsync(CancellationToken cancellationToken);
    void Rollback();
    Task RollbackAsync(CancellationToken cancellationToken);
}
