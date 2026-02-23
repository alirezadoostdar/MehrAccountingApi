namespace Mehr.Domain.Contacts.Contracts;

public interface IStateRepository
{
    Task<List<State>> GetAll();
}
