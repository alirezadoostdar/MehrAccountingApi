using Mehr.Domain.Users;
using Mehr.Domain.Users.Contracts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Mehr.Infarstructure.Users;

public class EfUserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public EfUserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByIdAsync(int id, CancellationToken cancellation)
    {
        var user = await _context.Users.FindAsync(id, cancellation);
        return user;
    }

    public async Task<User?> GetUserByUsernameAsync(string userName, CancellationToken cancellationToken)
    {
        return await _context.Users.Where(x => x.UserName == userName)
            .FirstOrDefaultAsync();
    }
}
