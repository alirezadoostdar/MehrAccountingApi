using Mehr.Domain.Users;
using Mehr.Domain.Users.Contracts;

namespace Mehr.Infarstructure.Users;

public class EfUserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public EfUserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetUserById(int id, CancellationToken cancellation)
    {
        return await _context.Users.FindAsync(id, cancellation);
    }
}
