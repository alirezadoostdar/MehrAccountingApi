using Mehr.Domain.Interfaces;
using Mehr.Domain.Zones;
using Microsoft.EntityFrameworkCore;

namespace Mehr.Infarstructure.Zones;

public class EfZoneRepository : IZoneRepository
{
    private readonly ApplicationDbContext _context;

    public EfZoneRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Zone zone, CancellationToken cancellationToken)
    {
        await _context.Zones.AddAsync(zone,cancellationToken);
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

    public void Update(Zone zone)
    {
         _context.Update(zone);
    }
}
