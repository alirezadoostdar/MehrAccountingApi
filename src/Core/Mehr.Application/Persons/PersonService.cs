using Mehr.Application.Persons.Contracts;
using Mehr.Domain.Persons;
using Mehr.Domain.Persons.Contracts;
using Mehr.SharedKernel;

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

    public Task<Result<Person>> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
