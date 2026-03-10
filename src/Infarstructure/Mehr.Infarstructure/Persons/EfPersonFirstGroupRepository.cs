using Mehr.Domain.Entities.Persons;
using Mehr.Domain.Persons.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Mehr.Infarstructure.Persons;

public class EfPersonFirstGroupRepository : IPersonFirstGroupRepository
{
    private readonly ApplicationDbContext _context;

    public EfPersonFirstGroupRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Delete(PersonFirstGroup personFirstGroup)
    {
        _context.Remove(personFirstGroup);
    }

    public async Task<List<PersonFirstGroup>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.PersonFirstGroups.ToListAsync(cancellationToken);
    }

    public async Task<PersonFirstGroup?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.PersonFirstGroups.FindAsync(id, cancellationToken);
    }

    public async Task<PersonFirstGroup?> GetByIdNoTarackAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.PersonFirstGroups
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public void Update(PersonFirstGroup personFirstGroup)
    {
        _context.Update(personFirstGroup);
    }
}
