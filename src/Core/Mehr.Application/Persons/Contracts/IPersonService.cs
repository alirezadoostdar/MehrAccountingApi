using Mehr.Application.Persons.Contracts.Dtos;
using Mehr.Domain.Persons;
using Mehr.SharedKernel;

namespace Mehr.Application.Persons.Contracts;

public interface IPersonService
{
    Task<Result<Person>> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<Result<GetPersonFirstGroupDto>> GetFirstGroupByIdAsync(int id, CancellationToken cancellationToken);
    Task<Result<List<GetPersonFirstGroupDto>>> GetAllFirtGroupAsync(CancellationToken cancellationToken);
    Task<Result<bool>> DeleteFirstGroupAsync(int id, CancellationToken cancellationToken);
    Task<Result<bool>> UpdateFirstGroupAsync(int id, CancellationToken cancellationToken);
}
