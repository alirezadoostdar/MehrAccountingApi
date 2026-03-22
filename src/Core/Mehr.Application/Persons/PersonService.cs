using Mehr.Application.Common.Contracts;
using Mehr.Application.Persons.Contracts;
using Mehr.Application.Persons.Contracts.Dtos;
using Mehr.Application.Persons.Contracts.Exceptions;
using Mehr.Domain.Contacts.Dtos;
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
    private readonly IPersonSecondGroupRepository _secondGroupRepository;
    private readonly ICacheService _cacheService;
    public const string personFirstGroupCacheKey = "personFirstGroup";
    public const string personSecondGroupCacheKey = "personSecondGroup";

    public PersonService(
        IPersonRepository repository,
        IUnitOfWork unitOfWork,
        IPersonFirstGroupRepository firstGroupRepository,
        IPersonSecondGroupRepository secondGroupRepository,
        ICacheService cacheService)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _firstGroupRepository = firstGroupRepository;
        _secondGroupRepository = secondGroupRepository;
        _cacheService = cacheService;
    }

    public async Task<Result<int>> AddFirstGroupAsync(AddPersonFirstGroupDto dto, CancellationToken cancellationToken)
    {
        var group = await _firstGroupRepository.GetByTitleAsync(dto.Title, cancellationToken);
        if (group is not null)
            return Result.Failure<int>(PersonGroupErrors.IsDuplicate(dto.Title));

        var firstGroup = new PersonFirstGroup
        {
            Title = dto.Title.Trim(),
        };

        await _firstGroupRepository.AddFirstGroupAsync(firstGroup, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return firstGroup.Id;
    }

    public async Task<Result<int>> AddSecondGroupAsync(AddPersonSecondGroupDto dto, CancellationToken cancellationToken)
    {
        var group = await _secondGroupRepository.GetByTitleAsync(dto.Title, cancellationToken);
        if (group is not null)
            return Result.Failure<int>(PersonGroupErrors.IsDuplicate(dto.Title));

        var secondGroup = new PersonSecondGroup
        {
            Title = dto.Title.Trim(),
        };

        await _secondGroupRepository.AddAsync(secondGroup, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return secondGroup.Id;
    }

    public async Task<Result<bool>> DeleteFirstGroupAsync(int id, CancellationToken cancellationToken)
    {
        var personGroup = await _firstGroupRepository.GetByIdAsync(id, cancellationToken);

        if (personGroup is null)
            return Result.Failure<bool>(PersonGroupErrors.NotFound(id));

        var isUsed = await _firstGroupRepository.IsUsed(id, cancellationToken);
        if (isUsed)
            return Result.Failure<bool>(PersonGroupErrors.IsUsed(id));

        _firstGroupRepository.Delete(personGroup);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _cacheService.RemoveAsync(personFirstGroupCacheKey, cancellationToken);
        return true;
    }

    public async Task<Result<bool>> DeleteSecondGroupAsync(int id, CancellationToken cancellationToken)
    {
        var personGroup = await _secondGroupRepository.GetByIdAsync(id, cancellationToken);

        if (personGroup is null)
            return Result.Failure<bool>(PersonGroupErrors.NotFound(id));

        var isUsed = await _secondGroupRepository.IsUsed(id, cancellationToken);
        if (isUsed)
            return Result.Failure<bool>(PersonGroupErrors.IsUsed(id));

        _secondGroupRepository.Delete(personGroup);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _cacheService.RemoveAsync(personSecondGroupCacheKey, cancellationToken);
        return true;
    }

    public async Task<Result<List<GetPersonFirstGroupDto>>> GetAllFirtGroupAsync(CancellationToken cancellationToken)
    {

        var cacheList = await _cacheService.GetAsync<List<GetPersonFirstGroupDto>>(
            personFirstGroupCacheKey,
            cancellationToken);
        if (cacheList is not null)
            return cacheList;

        var list = await _firstGroupRepository
            .GetAllAsync(cancellationToken);


        var DtoList = list.Select(x => new GetPersonFirstGroupDto
        {
            Id = x.Id,
            title = x.Title,
        }).ToList();

        await _cacheService.SetAsync<List<GetPersonFirstGroupDto>>(
           personFirstGroupCacheKey,
           DtoList,
           TimeSpan.FromMinutes(20),
           TimeSpan.FromMinutes(5),
           cancellationToken);

        return DtoList;

    }

    public async Task<Result<List<GetPersonSecondGroupDto>>> GetAllSecondGroupAsync(CancellationToken cancellationToken)
    {
        var cacheList = await _cacheService.GetAsync<List<GetPersonSecondGroupDto>>(
            personSecondGroupCacheKey,
            cancellationToken);

        if (cacheList is not null)
            return cacheList;


        var list = await _secondGroupRepository
            .GetAllAsync(cancellationToken);

        var dtoList = list.Select(x => new GetPersonSecondGroupDto
        {
            Id = x.Id,
            title = x.Title
        }).ToList();

        await _cacheService.SetAsync<List<GetPersonSecondGroupDto>>(
            personSecondGroupCacheKey,
            dtoList,
            TimeSpan.FromMinutes(20),
            TimeSpan.FromMinutes(5),
            cancellationToken);

        return dtoList;
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

    public Task<Result<GetPersonSecondGroupDto>> GetSecondGroupByIdAsync(int id, CancellationToken cancellationToken)
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

        personGroup.Title = dto.Title.Trim();

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        await _cacheService.RemoveAsync(personFirstGroupCacheKey, cancellationToken);
        return true;

    }

    public async Task<Result<bool>> UpdateSecondGroupAsync(int id, UpdatePersonSecondGroupDto dto, CancellationToken cancellationToken)
    {
        var personGroup = await _secondGroupRepository.GetByIdAsync(id, cancellationToken);

        if (personGroup is null)
            return Result.Failure<bool>(PersonGroupErrors.NotFound(id));

        personGroup.Title = dto.Title.Trim();

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _cacheService.RemoveAsync(personSecondGroupCacheKey, cancellationToken);
        return true;
    }
}
