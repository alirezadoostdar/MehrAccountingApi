using Mehr.Application.Contacts.Contracts.Dtos;
using Mehr.Domain.Contacts.Dto;
using Mehr.Domain.Contacts.Dtos;
using Mehr.SharedKernel;

namespace Mehr.Application.Contacts.Contracts;

public interface IContactService
{
    Task<Result<GetContactDto>> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<Result<List<GetStateDto>>> GetAllStateAsync(CancellationToken cancellationToken);
    Task<Result<List<GetCityDto>>> GetAllCityAsync(int stateId, CancellationToken cancellationToken);
    Task<Result<List<GetContactTypeDto>>> GetAllContactTypeAsync(CancellationToken cancellationToken);
}
