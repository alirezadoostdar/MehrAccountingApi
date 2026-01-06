using Mehr.Domain.Users;
using Mehr.Domain.Users.Contracts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Mehr.Infarstructure.Users;

public class EfRoleRepository : IRoleRepository
{
    private readonly ApplicationDbContext _context;

    public EfRoleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<RolePolicy_QueryModel>> GetPolicyList(int roleId, CancellationToken cancellationToken)
    {
        var policies = await _context.RolePloicies_QueryModel
            .FromSqlRaw("EXEC GetGroupIDPolicys @GID",
            new SqlParameter("@GID", roleId))
        .ToListAsync(cancellationToken);
        if (roleId == 1)
        {
            foreach (var policy in policies)
            {
                policy.Value = 1;
            }
        }
        return policies;
    }
}
