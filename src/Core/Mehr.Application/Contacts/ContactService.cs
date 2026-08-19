using Mehr.Application.Common.Contracts;
using Mehr.Application.Contacts.Contracts;
using Mehr.Application.Contacts.Contracts.Dtos;
using Mehr.Application.Contacts.Contracts.Exceprions;
using Mehr.Domain.Contacts;
using Mehr.Domain.Contacts.Contracts;
using Mehr.Domain.Contacts.Dto;
using Mehr.Domain.Contacts.Dtos;
using Mehr.Domain.Paginations;
using Mehr.Domain.Users;
using Mehr.SharedKernel;
using Microsoft.Extensions.Caching.Memory;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using System.Threading;

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

    public async Task<Result<int>> AddContactAsync(AddContactDto dto, CancellationToken cancellationToken)
    {
        var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

        var point = geometryFactory.CreatePoint(
            new Coordinate(Convert.ToDouble( dto.Longitude), Convert.ToDouble(dto.Latitude)));

        var contact = new ContactInfo
        {
            Name = dto.Name,
            ShopName = dto.ShopName,
            Address = dto.Address,
            CityId = dto.CityId,
            StateId = dto.StateId,
            ZoneId = dto.ZoneId,
            Comment = dto.Comment,
            TelegramId = dto.TelegramId,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
            TelegramMobileNumber = dto.TelegramMobileNumber,
            SecurityType = 0,
            Location = point,
            Numbers = dto.Numbers
            .Select(x => new ContactNumber
            {
                Number = x.Number,
                Title = x.Title,
                ContactTypeId = x.TypeId
            }).ToList()
        };

        if (dto.ImageBase64 is not null)
        {
            var imageBytes = Convert.FromBase64String(dto.ImageBase64);
            contact.Image = new ContactImage
            {
                Image = imageBytes,
                Name = "image"
            };
        }

        await _repository.AddAsync(contact, cancellationToken);
        await _uow.SaveChangesAsync(cancellationToken);
        return contact.Id;

    }

    public async Task<Result<bool>> DeleteContactAsync(int id, CancellationToken cancellationToken)
    {
        var contact = await _repository.GetByIdAsync(id, cancellationToken);
        if(contact is null)
            return Result.Failure<bool>(ContactErrors.NotFound(id));

        _repository.Delete(contact);
        await _uow.SaveChangesAsync(cancellationToken);
        return true;
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

    public async Task<Result<List<ContactListItemDto>>> GetAllContactListAsync(
        PaginationRequestQuery query,
        CancellationToken cancellationToken)
    {
        var cachKey = $"contactList";
        var cached = await _cacheService.GetAsync<List<ContactListItemDto>>(cachKey, cancellationToken);
        if (cached is not null) return cached;

        var contactList = await _repository.GetAllAsync(cancellationToken);

        await _cacheService.SetAsync<List<ContactListItemDto>>(
            cachKey,
            contactList,
            TimeSpan.FromMinutes(20),
            TimeSpan.FromMinutes(5),
            cancellationToken);
        return contactList;
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
        var contact = await _repository.GetByIdNoTrackAsync(id, cancellationToken);

        if (contact is null)
            return Result.Failure<GetContactDto>(ContactErrors.NotFound(id));

        var dto = new GetContactDto
        {
            Id = contact.Id,
            Name = contact.Name,
            Address = contact.Address,
            Comment = contact.Comment,
            Longitude = contact.Longitude,
            Latitude = contact.Latitude,
            ShopName = contact.ShopName,
            StateId = contact.StateId,
            State = contact.State.Title,
            CityId = contact.CityId,
            City = contact.City.Title,
            ZoneId = contact.ZoneId,
            Zone = contact.Zone.Title,
            TelegramId = contact.TelegramId,
            TelegramMobileNumber = contact.TelegramMobileNumber,
            Numbers = contact.Numbers
            .Select(x => new GetContactNumbersDto
            {
                Id = x.Id,
                Number = x.Number,
                Title = x.Title,
                Type = x.ContactType.Title,
                TypeId = x.ContactTypeId
            }).ToList()
        };
        return dto;
    }

    public async Task<Result<bool>> UpdateContactAsync(int id, UpdateContactDto dto, CancellationToken cancellation)
    {

        var contact = await _repository.GetByIdAsync(id, cancellation);
        if (contact is null)
            return Result.Failure<bool>(ContactErrors.NotFound(id));

        var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

        var point = geometryFactory.CreatePoint(
            new Coordinate(Convert.ToDouble(dto.Longitude), Convert.ToDouble(dto.Latitude)));

        contact.Name = dto.Name;
        contact.Address = dto.Address;
        contact.Comment = dto.Comment;
        contact.Longitude = dto.Longitude;
        contact.Latitude = dto.Latitude;
        contact.TelegramId = dto.TelegramId;
        contact.TelegramMobileNumber = dto.TelegramMobileNumber;
        contact.ShopName = dto.ShopName;
        contact.CityId = dto.CityId;
        contact.StateId = dto.StateId;
        contact.ZoneId = dto.ZoneId;
        contact.Location = point;
        contact.Numbers = dto.Numbers.Select(x => new ContactNumber
        {
            Id = x.Id,
            Number = x.Number,
            ContactTypeId = x.TypeId,
            Title = x.Title
        }).ToList();

        if (dto.ImageBase64 is not null)
        {
            var imageBytes = Convert.FromBase64String(dto.ImageBase64);
            contact.Image = new ContactImage
            {
                Image = imageBytes,
                Name = "image"
            };
        }
        else
        {
            contact.Image = null;
        }

        await _uow.SaveChangesAsync(cancellation);
        return true;
    }
}
