using Mehr.Domain.Users;
using Mehr.Domain.Users.Contracts;

namespace Mehr.Infarstructure.Users;

internal class EfUserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public EfUserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<User> GetUserById(int id, CancellationToken cancellation)
    {
        return _context.
    }
}
