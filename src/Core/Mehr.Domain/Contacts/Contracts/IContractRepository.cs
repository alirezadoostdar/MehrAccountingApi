using Mehr.Domain.Contacts.Dtos;
using Mehr.Domain.Paginations;

namespace Mehr.Domain.Contacts.Contracts;

public interface IContractRepository
{
    Task<ContactInfo?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<ContactInfo?> GetByIdNoTrackAsync(int id, CancellationToken cancellationToken);
    Task AddAsync(ContactInfo contactInfo, CancellationToken cancellationToken);
    void Delete(ContactInfo contactInfo);
    void Update(ContactInfo contactInfo);
    Task<PageResult<List<ContactListItemDto>>> GetAllAsync(PaginationRequestQuery query, CancellationToken cancellationToken);
}
