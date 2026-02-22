using Mehr.Domain.Contacts;
using Mehr.Domain.Contacts.Contracts;

namespace Mehr.Infarstructure.Contacts;

public class EfContactRepository : IContractRepository
{
    private readonly ApplicationDbContext _context;

    public EfContactRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ContactInfo?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Contacts.FindAsync(id, cancellationToken);
    }
}
