namespace Mehr.Domain.Users.Contracts;

public interface IUserRepository
{

    Task<User?> GetUserByIdAsync(int id, CancellationToken cancellation);
    Task<User?> GetUserByUsernameAsync(string userName, CancellationToken cancellationToken);
    
}
