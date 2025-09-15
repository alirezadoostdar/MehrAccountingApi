using Mehr.Domain.Entities.Accounts;
using Mehr.Domain.Interfaces.DetailedAccounts;

namespace Mehr.Infarstructure.DetailedAccounts;

public class EfDetailedAccountRepository : IDetailedAccountRepository
{
    private readonly ApplicationDbContext _context;
    private readonly UnitOfWork _unitOfWork;

    public EfDetailedAccountRepository(ApplicationDbContext context, UnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    public void Add(DetailedAccount account)
    {
        throw new NotImplementedException();
    }

    public void Delete(DetailedAccount account)
    {
        throw new NotImplementedException();
    }

    public DetailedAccount GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(DetailedAccount account)
    {
        throw new NotImplementedException();
    }
}
