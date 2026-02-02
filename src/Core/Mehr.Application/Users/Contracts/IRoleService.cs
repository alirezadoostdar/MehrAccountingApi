using Mehr.Domain.Users;
using System.Threading;

namespace Mehr.Application.Users.Contracts;

public interface IRoleService
{
    Task<List<RolePolicy_QueryModel>> GetPolicyList(int roleId, CancellationToken cancellationToken);
    Task<HashSet<string>> GetActivePolicyList(int roleId, CancellationToken cancellationToken);
}
