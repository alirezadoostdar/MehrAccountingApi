namespace Mehr.Domain.Contacts.Contracts;

public interface IContractRepository
{
    Task<ContactInfo?> GetByIdAsync(int id, CancellationToken cancellationToken);
}
