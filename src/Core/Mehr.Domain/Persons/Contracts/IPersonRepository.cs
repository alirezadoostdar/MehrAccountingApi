namespace Mehr.Domain.Persons.Contracts;

public interface IPersonRepository
{
    Task<Person?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task AddAsync(Person person, CancellationToken cancellationToken);
}
