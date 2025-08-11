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

    public async Task AddAsync(Zone zone)
    {
        await _context.Zones.AddAsync(zone);
    }

    public void Delete(Zone zone)
    {
        _context.Zones.Remove(zone);
    }

    public async Task<List<Zone>> GetAllAsync()
    {
        return await _context.Zones.ToListAsync();
    }

    public async Task<Zone?> GetByIdAsync(int id)
    {
        return await _context.Zones.FindAsync(id);
    }

    public void UpdateAsync(Zone zone)
    {
         _context.Update(zone);
    }
}
