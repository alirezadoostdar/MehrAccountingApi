using Mehr.Application.Contacts.Contracts;
using Mehr.Application.Contacts.Contracts.Dtos;
using Mehr.Domain.Contacts.Contracts;
using Mehr.SharedKernel;

namespace Mehr.Application.Contacts;

public class ContactService : IContactService
{
    private readonly IContractRepository _repository;
    private readonly IUnitOfWork _uow;

    public ContactService(IContractRepository repository, IUnitOfWork uow)
    {
        _repository = repository;
        _uow = uow;
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
