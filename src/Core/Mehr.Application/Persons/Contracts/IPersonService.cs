using Mehr.Domain.Persons;
using Mehr.SharedKernel;

namespace Mehr.Application.Persons.Contracts;

public interface IPersonService
{
    Task<Result<Person>> GetByIdAsync(int id, CancellationToken cancellationToken);
}
