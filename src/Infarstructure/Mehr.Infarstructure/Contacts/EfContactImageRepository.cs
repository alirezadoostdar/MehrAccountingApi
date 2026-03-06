using Mehr.Domain.Contacts;
using Mehr.Domain.Contacts.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Mehr.Infarstructure.Contacts;

public class EfContactImageRepository : IContactImageRepository
{
    private readonly ApplicationDbContext _context;

    public EfContactImageRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ContactImage>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.ContactImages.ToListAsync(cancellationToken);
    }
}
