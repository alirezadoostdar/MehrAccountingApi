using Mehr.Application.Users.Contracts;
using Mehr.Domain.Users.Contracts;

namespace Mehr.Application.Users;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _repository;

    public RoleService(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<HashSet<string>> GetPolicyList(int roleId, CancellationToken cancellationToken)
    {
        var policyList = await _repository.GetPolicyList(roleId, cancellationToken);
        return policyList.Where(x => x.Value == 1)
            .Select(x => x.Id.ToString())
            .ToHashSet();
    }
}
