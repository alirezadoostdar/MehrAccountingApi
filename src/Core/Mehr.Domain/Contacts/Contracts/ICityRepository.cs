using Mehr.Domain.Contacts.Dtos;

namespace Mehr.Domain.Contacts.Contracts;

public interface ICityRepository
{
    Task<List<GetCityDto>> GetAllAsync(int stateId, CancellationToken cancellationToken);
}
