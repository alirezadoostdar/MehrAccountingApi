using Mehr.Application.Persons.Contracts.Dtos;
using Mehr.Domain.Persons;
using Mehr.SharedKernel;

namespace Mehr.Application.Persons.Contracts;

public interface IPersonService
{
    Task<Result<Person>> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<Result<GetPersonFirstGroupDto>> GetFirstGroupByIdAsync(int id, CancellationToken cancellationToken);
    Task<Result<List<GetPersonFirstGroupDto>>> GetAllFirtGroupAsync(CancellationToken cancellationToken);
    Task<Result<int>> AddFirstGroupAsync(AddPersonFirstGroupDto dto, CancellationToken cancellationToken);
    Task<Result<bool>> DeleteFirstGroupAsync(int id, CancellationToken cancellationToken);
    Task<Result<bool>> UpdateFirstGroupAsync(int id, UpdatePersonFirstGroupDto dto, CancellationToken cancellationToken);


    Task<Result<GetPersonSecondGroupDto>> GetSecondGroupByIdAsync(int id, CancellationToken cancellationToken);
    Task<Result<List<GetPersonSecondGroupDto>>> GetAllSecondGroupAsync(CancellationToken cancellationToken);
    Task<Result<int>> AddSecondGroupAsync(AddPersonSecondGroupDto dto, CancellationToken cancellationToken);
    Task<Result<bool>> DeleteSecondGroupAsync(int id, CancellationToken cancellationToken);
    Task<Result<bool>> UpdateSecondGroupAsync(int id, UpdatePersonSecondGroupDto dto, CancellationToken cancellationToken);
}
