using Mehr.Application.Common.Contracts;
using Mehr.Application.Contacts.Contracts;
using Mehr.Application.Contacts.Contracts.Dtos;
using Mehr.Domain.Contacts;
using Mehr.Domain.Contacts.Contracts;
using Mehr.Domain.Contacts.Dto;
using Mehr.Domain.Contacts.Dtos;
using Mehr.Domain.Users;
using Mehr.SharedKernel;
using Microsoft.Extensions.Caching.Memory;

namespace Mehr.Application.Contacts;

public class ContactService : IContactService
{
    private readonly IContractRepository _repository;
    private readonly IUnitOfWork _uow;
    private readonly IStateRepository _stateRepository;
    private readonly ICityRepository _cityRepository;
    private readonly ICacheService _cacheService;
    private readonly IContactTypeRepository _contactTypeRepository;

    public ContactService(
        IContractRepository repository,
        IUnitOfWork uow,
        IStateRepository stateRepository,
        ICityRepository cityRepository,
        ICacheService cacheService,
        IContactTypeRepository contactTypeRepository)
    {
        _repository = repository;
        _uow = uow;
        _stateRepository = stateRepository;
        _cityRepository = cityRepository;
        _cacheService = cacheService;
        _contactTypeRepository = contactTypeRepository;
    }

    public async Task<Result<List<GetCityDto>>> GetAllCityAsync(int stateId, CancellationToken cancellationToken)
    {
        var cacheKey = $"cities:{stateId}";

        var cached = await _cacheService.GetAsync<List<GetCityDto>>(cacheKey, cancellationToken);

        if (cached is not null)
            return cached;

        var cityList = await _cityRepository.GetAllAsync(stateId, cancellationToken);

        await _cacheService.SetAsync<List<GetCityDto>>(
           cacheKey,
           cityList,
           TimeSpan.FromMinutes(20),
           TimeSpan.FromMinutes(5),
           cancellationToken);

        return cityList;
    }

    public async Task<Result<List<GetContactTypeDto>>> GetAllContactTypeAsync(CancellationToken cancellationToken)
    {
        var cacheKey = $"contactTypes";

        var cached = await _cacheService.GetAsync<List<GetContactTypeDto>>(cacheKey, cancellationToken);

        if (cached is not null)
            return cached;

        var contactTypeList = await _contactTypeRepository.GetAllAsync(cancellationToken);

        await _cacheService.SetAsync<List<GetContactTypeDto>>(
           cacheKey,
           contactTypeList,
           TimeSpan.FromMinutes(20),
           TimeSpan.FromMinutes(5),
           cancellationToken);

        return contactTypeList;
    }

    public async Task<Result<List<GetStateDto>>> GetAllStateAsync(CancellationToken cancellationToken)
    {
        var cacheKey = $"states";

        var cached = await _cacheService.GetAsync<List<GetStateDto>>(cacheKey, cancellationToken);

        if (cached is not null)
            return cached;

        var stateList = await _stateRepository.GetAllAsync(cancellationToken);

        await _cacheService.SetAsync<List<GetStateDto>>(
           cacheKey,
           stateList,
           TimeSpan.FromMinutes(20),
           TimeSpan.FromMinutes(5),
           cancellationToken);

        return stateList;
    }

    public async Task<Result<GetContactDto>> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var contact = await _repository.GetByIdAsync(id, cancellationToken);

        var dto = new GetContactDto
        {
            Id = contact.Id,
            Name = contact.Name,
            Address = contact.Address,
            Comment = contact.Comment,
            Longitude = contact.Longitude,
            Latitude = contact.Latitude,
        };
        return dto;
    }
}
