using Mehr.Domain.Users;
using System.Threading;

namespace Mehr.Application.Users.Contracts;

public interface IRoleService
{
    Task<HashSet<string>> GetPolicyList(int roleId, CancellationToken cancellationToken);
}
