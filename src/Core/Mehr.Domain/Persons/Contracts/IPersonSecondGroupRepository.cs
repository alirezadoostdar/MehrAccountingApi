namespace Mehr.Domain.Persons.Contracts;

public interface IPersonSecondGroupRepository
{
    Task<PersonSecondGroup?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<PersonSecondGroup?> GetByTitleAsync(string title, CancellationToken cancellationToken);
    Task<PersonSecondGroup?> GetByIdNoTarackAsync(int id, CancellationToken cancellationToken);
    Task<List<PersonSecondGroup>> GetAllAsync(CancellationToken cancellationToken);
    Task<bool> IsUsed(int id, CancellationToken cancellationToken);
    Task AddFirstGroupAsync(PersonSecondGroup secondGroup, CancellationToken cancellationToken);
    void Delete(PersonSecondGroup personSecondGroup);
    void Update(PersonSecondGroup personSecondGroup);
}
