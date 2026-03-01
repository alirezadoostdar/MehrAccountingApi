using Mehr.Domain.Contacts.Dto;

namespace Mehr.Domain.Contacts.Contracts;

public interface IContactTypeRepository
{
    Task<List<GetContactTypeDto>> GetAllAsync(CancellationToken cancellationToken);
}
