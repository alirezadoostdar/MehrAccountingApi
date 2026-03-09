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

    public async Task AddAsync(ContactInfo contactInfo, CancellationToken cancellationToken)
    {
        await _context.Contacts.AddAsync(contactInfo, cancellationToken);
    }

    public void Delete(ContactInfo contactInfo)
    {
        _context.Contacts.Remove(contactInfo);
    }

    public async Task<ContactInfo?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Contacts
            .Where(x => x.Id == id)
            .Include(x => x.Numbers)
            .ThenInclude(t => t.ContactType)
            .Include(i => i.Image)
            .Include(z => z.Zone)
            .Include(s => s.State)
            .Include(c => c.City)
            //.AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<ContactInfo?> GetByIdNoTrackAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Contacts
            .Where(x => x.Id == id)
            .Include(x => x.Numbers)
            .ThenInclude(t => t.ContactType)
            .Include(i => i.Image)
            .Include(z => z.Zone)
            .Include(s => s.State)
            .Include(c => c.City)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
    }

    public void Update(ContactInfo contactInfo)
    {
        _context.Contacts.Update(contactInfo);
    }
}
