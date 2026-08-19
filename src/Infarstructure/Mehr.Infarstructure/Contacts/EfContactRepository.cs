using Mehr.Domain.Contacts;
using Mehr.Domain.Contacts.Contracts;
using Mehr.Domain.Contacts.Dtos;
using Mehr.Domain.Paginations;
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

    public async Task<PageResult<ContactListItemDto> GetAllAsync(
        PaginationRequestQuery query,
        CancellationToken cancellationToken)
    {
      var list = await  _context.Contacts
            .Where(c => query.Search == null || c.Name.Contains(query.Search))
            .OrderBy(c => c.Name)
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .Include(s => s.State)
            .Include(c => c.City)
            .Include(z => z.Zone)
            .Include(n => n.Numbers)
            .Select(x => new ContactListItemDto
            {
                Id = x.Id,
                Name = x.Name,
                Company = x.ShopName,
                Address = x.Address,
                City = x.City.Title,
                State = x.State.Title,
                Zone = x.Zone.Title,
                Mobile = x.Numbers.Where(y => y.ContactTypeId == 2).FirstOrDefault().Number,
                Phone = x.Numbers.Where(y => y.ContactTypeId == 1).FirstOrDefault().Number,
                ZipCode = x.Numbers.Where(y => y.ContactTypeId == 3).FirstOrDefault().Number
            }).ToListAsync(cancellationToken);

        var total = await _context.Contacts.CountAsync(cancellationToken);
        var result = new PageResult<ContactListItemDto>
        {
            Data = list,
            Meta = new PaginationMeta
            {
                CurrentPage = query.Page,
                PageSize = query.PageSize,
                TotalItems = total,
                TotalPages = total,
            }
        };

        return result;
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
