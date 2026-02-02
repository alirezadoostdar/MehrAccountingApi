using Mehr.Application.Users.Contracts;
using Mehr.Domain.Users;
using Mehr.Domain.Users.Contracts;

namespace Mehr.Application.Users;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _repository;

    public RoleService(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<HashSet<string>> GetActivePolicyList(int roleId, CancellationToken cancellationToken)
    {
        var policyList = await _repository.GetPolicyList(roleId, cancellationToken);
        return policyList.Where(x => x.Value == 1)
            .Select(x => x.Id.ToString())
            .ToHashSet();
    }

    public async Task<List<RolePolicy_QueryModel>> GetPolicyList(int roleId, CancellationToken cancellationToken)
    {
        return await _repository.GetPolicyList(roleId, cancellationToken);
    }


}
