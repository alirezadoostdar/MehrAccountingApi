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

    public async Task AddFirstGroupAsync(PersonFirstGroup firsGroup, CancellationToken cancellationToken)
    {
        await _context.PersonFirstGroups.AddAsync(firsGroup, cancellationToken);
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
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<PersonFirstGroup?> GetByTitleAsync(string title, CancellationToken cancellationToken)
    {
        return await _context.PersonFirstGroups
            .Where(x => x.Title == title)
            .AsNoTracking()
            .FirstOrDefaultAsync (cancellationToken);
    }

    public void Update(PersonFirstGroup personFirstGroup)
    {
        _context.Update(personFirstGroup);
    }
}
