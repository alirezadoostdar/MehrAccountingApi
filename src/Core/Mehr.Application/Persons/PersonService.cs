using Mehr.Application.Persons.Contracts;
using Mehr.Application.Persons.Contracts.Dtos;
using Mehr.Application.Persons.Contracts.Exceptions;
using Mehr.Domain.Entities.Persons;
using Mehr.Domain.Persons;
using Mehr.Domain.Persons.Contracts;
using Mehr.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Mehr.Application.Persons;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPersonFirstGroupRepository _firstGroupRepository;

    public PersonService(
        IPersonRepository repository,
        IUnitOfWork unitOfWork,
        IPersonFirstGroupRepository firstGroupRepository)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _firstGroupRepository = firstGroupRepository;
    }

    public async Task<Result<int>> AddFirstGroupAsync(AddPersonFirstGroupDto dto, CancellationToken cancellationToken)
    {
        var group = await _firstGroupRepository.GetByTitleAsync(dto.Title, cancellationToken);
        if (group is not null)
            return Result.Failure<int>(PersonGroupErrors.IsDuplicate(dto.Title));

        var firstGroup = new PersonFirstGroup
        {
            Title = dto.Title,
        };

        await _firstGroupRepository.AddFirstGroupAsync(firstGroup, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return firstGroup.Id;
    }

    public Task<Result<bool>> DeleteFirstGroupAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<List<GetPersonFirstGroupDto>>> GetAllFirtGroupAsync(CancellationToken cancellationToken)
    {
        var list = await _firstGroupRepository
            .GetAllAsync(cancellationToken);

        return list.Select(x => new GetPersonFirstGroupDto
        {
            Id = x.Id,
            title = x.Title,
        }).ToList();
            
    }

    public async Task<Result<Person>> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var person = await _repository.GetByIdAsync(id, cancellationToken);

        if (person is null)
            return Result.Failure<Person>(PersonErros.NotFound(id));

        return person;
    }

    public Task<Result<GetPersonFirstGroupDto>> GetFirstGroupByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<bool>> UpdateFirstGroupAsync(int id,
        UpdatePersonFirstGroupDto dto,
        CancellationToken cancellationToken)
    {
        var personGroup = await _firstGroupRepository.GetByIdAsync(id, cancellationToken);

        if (personGroup is null)
            return Result.Failure<bool>(PersonGroupErrors.NotFound(id));

        personGroup.Title = dto.Title;

        await _unitOfWork.SaveChangesAsync(cancellationToken);

    }
}
