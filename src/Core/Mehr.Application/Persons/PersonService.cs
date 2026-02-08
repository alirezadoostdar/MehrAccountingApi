using Mehr.Application.Persons.Contracts;
using Mehr.Application.Persons.Contracts.Exceptions;
using Mehr.Domain.Persons;
using Mehr.Domain.Persons.Contracts;
using Mehr.SharedKernel;
using System.Globalization;

namespace Mehr.Application.Persons;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public PersonService(IPersonRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Person>> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var person = await _repository.GetByIdAsync(id, cancellationToken);

        if (person is null)
            return Result.Failure<Person>(PersonErros.NotFound(id));

        return person;
    }
}
