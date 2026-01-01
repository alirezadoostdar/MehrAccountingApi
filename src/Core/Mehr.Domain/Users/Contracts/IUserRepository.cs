namespace Mehr.Domain.Users.Contracts;

public interface IUserRepository
{
    Task<User> GetUserById(int id, CancellationToken cancellation);
}
