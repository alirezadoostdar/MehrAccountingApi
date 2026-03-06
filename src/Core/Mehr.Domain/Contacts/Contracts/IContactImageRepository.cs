namespace Mehr.Domain.Contacts.Contracts;

public interface IContactImageRepository
{
    Task<List<ContactImage>> GetAllAsync();
}
