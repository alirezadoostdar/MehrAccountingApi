using Mehr.Domain.Contacts.Dtos;

namespace Mehr.Domain.Contacts.Contracts;

public interface IStateRepository
{
    Task<List<GetStateDto>> GetAllAsync(CancellationToken cancellation);
}
