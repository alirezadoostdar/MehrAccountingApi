using Mehr.Domain.Entities.Contacts;
using Mehr.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mehr.Infarstructure.Zones;

public class EfZoneRepository : IZoneRepository
{
    private readonly ApplicationDbContext _context;

    public EfZoneRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddAsync(Zone zone)
    {
        await _context.Zones.AddAsync(zone);
        return zone.Id;
    }

    public void Delete(Zone zone)
    {
        _context.Zones.Remove(zone);
    }

    public async Task<List<Zone>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Zones.ToListAsync(cancellationToken);
    }

    public async Task<Zone?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Zones.FindAsync(id, cancellationToken);
    }

    public async Task<Zone?> GetByTitleAsync(string title, CancellationToken cancellationToken)
    {
        return await _context.Zones.Where(x => x.Title == title).FirstOrDefaultAsync();
    }

    public void UpdateAsync(Zone zone)
    {
         _context.Update(zone);
    }
}
