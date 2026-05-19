using Mehr.Application.Common.Contracts;
using Mehr.Application.Persons.Contracts;
using Mehr.Application.Persons.Contracts.Dtos;
using Mehr.Application.Persons.Contracts.Exceptions;
using Mehr.Domain.Contacts;
using Mehr.Domain.Contacts.Dtos;
using Mehr.Domain.Entities.Persons;
using Mehr.Domain.Persons;
using Mehr.Domain.Persons.Contracts;
using Mehr.SharedKernel;
using NetTopologySuite.Geometries;
using NetTopologySuite;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        await _cacheService.RemoveAsync(personFirstGroupCacheKey, cancellationToken);
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
        await _cacheService.RemoveAsync(personSecondGroupCacheKey, cancellationToken);
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

    public async Task<Result<GetPersonFirstGroupDto>> GetFirstGroupByIdAsync(int id, CancellationToken cancellationToken)
    {
        var firstGroup = await _firstGroupRepository.GetByIdNoTarackAsync(id, cancellationToken);
        if (firstGroup is null)
            return Result.Failure<GetPersonFirstGroupDto>(PersonErros.NotFound(id));

        return new GetPersonFirstGroupDto
        {
            Id = firstGroup.Id,
            title = firstGroup.Title,
        };
    }

    public async Task<Result<GetPersonSecondGroupDto>> GetSecondGroupByIdAsync(int id, CancellationToken cancellationToken)
    {
        var secondGroup = await _secondGroupRepository.GetByIdNoTrackAsync(id, cancellationToken);
        if (secondGroup is null)
            return Result.Failure<GetPersonSecondGroupDto>(PersonErros.NotFound(id));

        return new GetPersonSecondGroupDto
        {
            Id = secondGroup.Id,
            title = secondGroup.Title
        };
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

    public async Task<Result<int>> AddPersonAsync(AddPersonDto dto, CancellationToken cancellationToken)
    {
        var person = new Person
        {
            Title = dto.Title,
            FirstGroupId = dto.FirstGroupId,
            SecondGroupId = dto.SecondGroupId,
            CategoryId = 1,
            Comment = dto.Comment,
            ShopName = dto.ShopName,
            CreditLimit = dto.CreditLimit,
            Code = dto.Code,
            Introducer = dto.Introducer,
            CreateAt = DateTime.Now,
            UpdateAt = DateTime.Now,
            SalePriceId = dto.SalePriceId,
            VisitorCostId = dto.VisitorCostId,
            VisitorBaseAmount = dto.VisitorBaseAmount,
            VisitorIncreaseAmount = dto.VisitorIncreaseAmount,
            VisitorIncresePercent = dto.VisitorIncresePercent,
            VisitorAutoDoc = dto.VisitorAutoDoc,
            VisitorGoodActiveStatus = dto.VisitorGoodActiveStatus,
            VisitorPercentActiveStatus = dto.VisitorPercentActiveStatus,
            VisitorProductGroupId = dto.VisitorProductGroupId,
            KindId = dto.KindId,
            IsForeign = dto.IsForeign,
            VisitorPercentChanging = dto.VisitorPercentChanging,
            CardNumber = dto.CardNumber,
            CardId1 = dto.CardId1,
            CardId2 = dto.CardId2,
            BirthdayDate = dto.BirthdayDate,
            Password = dto.Password,
            Credit = dto.Credit,
            PersonCustomerKindId = dto.PersonCustomerKindId,
            PersonCommercialId = dto.PersonCommercialId,
            Resume = dto.Resume,
            ShippingComment = dto.ShippingComment,
            FirstVisitorId = dto.FirstVisitorId,
            SecondVisitorId = dto.SecondVisitorId,
            VisitorColor = dto.VisitorColor,
            IsDriver = dto.IsDriver,
            IsEmployee = dto.IsEmployee,
            IsDistributor = dto.IsDistributor,
            IsUpdate = dto.IsUpdate,
            TaxKindId = dto.TaxKindId,
        };

        if (dto.ContactInfo is not null)
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            var point = geometryFactory.CreatePoint(
                new Coordinate(Convert.ToDouble(dto.ContactInfo.Longitude), Convert.ToDouble(dto.ContactInfo.Latitude)));

            person.ContactInfo = new ContactInfo
            {
                Name = dto.ContactInfo.Name,
                ShopName = dto.ContactInfo.ShopName,
                Address = dto.ContactInfo.Address,
                CityId = dto.ContactInfo.CityId,
                StateId = dto.ContactInfo.StateId,
                ZoneId = dto.ContactInfo.ZoneId,
                Comment = dto.ContactInfo.Comment,
                TelegramId = dto.ContactInfo.TelegramId,
                Latitude = dto.ContactInfo.Latitude,
                Longitude = dto.ContactInfo.Longitude,
                TelegramMobileNumber = dto.ContactInfo.TelegramMobileNumber,
                SecurityType = 0,
                Location = point,
                Numbers = dto.ContactInfo.Numbers
            .Select(x => new ContactNumber
            {
                Number = x.Number,
                Title = x.Title,
                ContactTypeId = x.TypeId
            }).ToList()
            };

            if (dto.ContactInfo.ImageBase64 is not null)
            {
                var imageBytes = Convert.FromBase64String(dto.ContactInfo.ImageBase64);
                person.ContactInfo.Image = new ContactImage
                {
                    Image = imageBytes,
                    Name = "image"
                };
            }
        }
        await _repository.AddAsync(person, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return person.Id;

    }

    public async Task<Result<bool>> UpdatePersonAsync(int id, UpdatePersonDto dto, CancellationToken cancellationToken)
    {
        var person = await _repository.GetByIdAsync(id, cancellationToken);
        if (person is not null)
            return Result.Failure<bool>(PersonErros.NotFound(id));

        person.Title = dto.Title;
        person.FirstGroupId = dto.FirstGroupId;
        person.SecondGroupId = dto.SecondGroupId;
        person.CategoryId = 1;
        person.Comment = dto.Comment;
        person.ShopName = dto.ShopName;
        person.CreditLimit = dto.CreditLimit;
        person.Code = dto.Code;
        person.Introducer = dto.Introducer;
        person.CreateAt = DateTime.Now;
        person.UpdateAt = DateTime.Now;
        person.SalePriceId = dto.SalePriceId;
        person.VisitorCostId = dto.VisitorCostId;
        person.VisitorBaseAmount = dto.VisitorBaseAmount;
        person.VisitorIncreaseAmount = dto.VisitorIncreaseAmount;
        person.VisitorIncresePercent = dto.VisitorIncresePercent;
        person.VisitorAutoDoc = dto.VisitorAutoDoc;
        person.VisitorGoodActiveStatus = dto.VisitorGoodActiveStatus;
        person.VisitorPercentActiveStatus = dto.VisitorPercentActiveStatus;
        person.VisitorProductGroupId = dto.VisitorProductGroupId;
        person.KindId = dto.KindId;
        person.IsForeign = dto.IsForeign;
        person.VisitorPercentChanging = dto.VisitorPercentChanging;
        person.CardNumber = dto.CardNumber;
        person.CardId1 = dto.CardId1;
        person.CardId2 = dto.CardId2;
        person.BirthdayDate = dto.BirthdayDate;
        person.Password = dto.Password;
        person.Credit = dto.Credit;
        person.PersonCustomerKindId = dto.PersonCustomerKindId;
        person.PersonCommercialId = dto.PersonCommercialId;
        person.Resume = dto.Resume;
        person.ShippingComment = dto.ShippingComment;
        person.FirstVisitorId = dto.FirstVisitorId;
        person.SecondVisitorId = dto.SecondVisitorId;
        person.VisitorColor = dto.VisitorColor;
        person.IsDriver = dto.IsDriver;
        person.IsEmployee = dto.IsEmployee;
        person.IsDistributor = dto.IsDistributor;
        person.IsUpdate = dto.IsUpdate;
        person.TaxKindId = dto.TaxKindId;

        if (dto.ContactInfo is not null)
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            var point = geometryFactory.CreatePoint(
                new Coordinate(Convert.ToDouble(dto.ContactInfo.Longitude), Convert.ToDouble(dto.ContactInfo.Latitude)));

            person.ContactInfo = new ContactInfo
            {
                Name = dto.ContactInfo.Name,
                ShopName = dto.ContactInfo.ShopName,
                Address = dto.ContactInfo.Address,
                CityId = dto.ContactInfo.CityId,
                StateId = dto.ContactInfo.StateId,
                ZoneId = dto.ContactInfo.ZoneId,
                Comment = dto.ContactInfo.Comment,
                TelegramId = dto.ContactInfo.TelegramId,
                Latitude = dto.ContactInfo.Latitude,
                Longitude = dto.ContactInfo.Longitude,
                TelegramMobileNumber = dto.ContactInfo.TelegramMobileNumber,
                SecurityType = 0,
                Location = point,
                Numbers = dto.ContactInfo.Numbers
            .Select(x => new ContactNumber
            {
                Number = x.Number,
                Title = x.Title,
                ContactTypeId = x.TypeId
            }).ToList()
            };

            if (dto.ContactInfo.ImageBase64 is not null)
            {
                var imageBytes = Convert.FromBase64String(dto.ContactInfo.ImageBase64);
                person.ContactInfo.Image = new ContactImage
                {
                    Image = imageBytes,
                    Name = "image"
                };
            }
        }
        await _repository.AddAsync(person, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
