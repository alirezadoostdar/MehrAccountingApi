using Mehr.Application.Contacts.Contracts;
using Mehr.Application.Contacts.Contracts.Dtos;
using Mehr.Domain.Contacts.Contracts;
using Mehr.Domain.Contacts.Dtos;
using Mehr.SharedKernel;

namespace Mehr.Application.Contacts;

public class ContactService : IContactService
{
    private readonly IContractRepository _repository;
    private readonly IUnitOfWork _uow;
    private readonly IStateRepository _stateRepository;

    public ContactService(
        IContractRepository repository,
        IUnitOfWork uow,
        IStateRepository stateRepository)
    {
        _repository = repository;
        _uow = uow;
        _stateRepository = stateRepository;
    }

    public async Task<Result<List<GetStateDto>>> GetAllStateAsync(CancellationToken cancellationToken)
    {
        return await _stateRepository.GetAllAsync(cancellationToken);
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
