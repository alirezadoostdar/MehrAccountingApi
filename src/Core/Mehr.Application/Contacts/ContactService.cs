using Mehr.Application.Contacts.Contracts;
using Mehr.Application.Contacts.Contracts.Dtos;
using Mehr.SharedKernel;

namespace Mehr.Application.Contacts;

public class ContactService : IContactService
{
    private readonly Icontac
    public Task<Result<GetContactDto>> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
