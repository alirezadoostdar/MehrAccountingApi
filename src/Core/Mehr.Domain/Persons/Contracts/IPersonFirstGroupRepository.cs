using Mehr.Domain.Entities.Persons;

namespace Mehr.Domain.Persons.Contracts;

public interface IPersonFirstGroupRepository
{
    Task<PersonFirstGroup?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<PersonFirstGroup?> GetByTitleAsync(string title, CancellationToken cancellationToken);
    Task<PersonFirstGroup?> GetByIdNoTarackAsync(int id, CancellationToken cancellationToken);
    Task<List<PersonFirstGroup>> GetAllAsync(CancellationToken cancellationToken);
    Task AddFirstGroupAsync(PersonFirstGroup firsGroup, CancellationToken cancellationToken);
    void Delete(PersonFirstGroup personFirstGroup);
    void Update(PersonFirstGroup personFirstGroup);
}
