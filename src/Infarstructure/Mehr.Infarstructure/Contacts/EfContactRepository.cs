using Mehr.Domain.Contacts;
using Mehr.Domain.Contacts.Contracts;
using Microsoft.EntityFrameworkCore;

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
        var numbers = await _context.ContactNumbers.ToListAsync(cancellationToken);
        return await _context.Contacts
            .Where(x => x.Id == id)
            .Include(x => x.Numbers)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
    }
}
