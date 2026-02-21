using Mehr.Application;

namespace Mehr.Infarstructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Begin()
    {
        _context.Database.BeginTransaction();
    }

    public async Task BeginAsync(CancellationToken cancellationToken)
    {
       await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    public void Commit()
    {
        _context.Database.CommitTransaction();
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await _context.Database.CommitTransactionAsync(cancellationToken);
    }

    public void Rollback()
    {
        _context.Database.RollbackTransaction();
    }

    public async Task RollbackAsync(CancellationToken cancellationToken)
    {
        await _context.Database.RollbackTransactionAsync(cancellationToken);
    }

    public void SaveChange()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync();
    }
}
