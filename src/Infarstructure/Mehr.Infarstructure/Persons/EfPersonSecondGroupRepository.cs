using Mehr.Domain.Persons;
using Mehr.Domain.Persons.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Mehr.Infarstructure.Persons;

public class EfPersonSecondGroupRepository : IPersonSecondGroupRepository
{
    private readonly ApplicationDbContext _context;

    public EfPersonSecondGroupRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(PersonSecondGroup secondGroup, CancellationToken cancellationToken)
    {
        await _context.PersonSecondGroups.AddAsync(secondGroup, cancellationToken);
    }

    public void Delete(PersonSecondGroup personSecondGroup)
    {
        _context.PersonSecondGroups.Remove(personSecondGroup);
    }

    public async Task<List<PersonSecondGroup>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.PersonSecondGroups.ToListAsync(cancellationToken);
    }

    public async Task<PersonSecondGroup?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.PersonSecondGroups.FindAsync(id, cancellationToken);
    }

    public async Task<PersonSecondGroup?> GetByIdNoTarackAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.PersonSecondGroups
            .Where(x => x.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<PersonSecondGroup?> GetByTitleAsync(string title, CancellationToken cancellationToken)
    {
        return await _context.PersonSecondGroups
            .Where(x => x.Title == title)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<bool> IsUsed(int id, CancellationToken cancellationToken)
    {
        return await _context.Persons
            .AnyAsync(x => x.SecondGroupId == id, cancellationToken);
    }

    public void Update(PersonSecondGroup personSecondGroup)
    {
        _context.Update(personSecondGroup);
    }
}