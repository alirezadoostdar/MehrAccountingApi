using Mehr.Application;

namespace Mehr.Infarstructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public void Begin()
    {
        _context.Database.BeginTransaction();
    }

    public async Task BeginAsync()
    {
       await _context.Database.BeginTransactionAsync();
    }

    public void Commit()
    {
        _context.Database.CommitTransaction();
    }

    public async Task CommitAsync()
    {
        await _context.Database.CommitTransactionAsync();
    }

    public void Rollback()
    {
        _context.Database.RollbackTransaction();
    }

    public async Task RollbackAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }

    public void SaveChange()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
