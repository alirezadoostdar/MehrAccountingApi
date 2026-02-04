using Mehr.Application.Common.Contracts;
using Mehr.Application.Users.Contracts;
using Mehr.Domain.Users;
using Mehr.Domain.Users.Contracts;

namespace Mehr.Application.Users;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _repository;
    private readonly ICacheService _cacheService;

    public RoleService(IRoleRepository repository, ICacheService cacheService)
    {
        _repository = repository;
        _cacheService = cacheService;
    }

    public async Task<HashSet<string>> GetActivePolicyList(int roleId, CancellationToken cancellationToken)
    {
        var cacheKey = $"permission:{roleId}";

        var cached = await _cacheService.GetAsync<HashSet<string>>(cacheKey, cancellationToken);

        if (cached is not null)
            return cached;

        var policyList = await _repository.GetPolicyList(roleId, cancellationToken);
        var hashList =  policyList.Where(x => x.Value == 1)
            .Select(x => x.Id.ToString())
            .ToHashSet();

        await _cacheService.SetAsync<HashSet<string>>(
           cacheKey,
           hashList,
           TimeSpan.FromMinutes(20),
           TimeSpan.FromMinutes(5),
           cancellationToken);

        return hashList;
    }

    public async Task<List<RolePolicy_QueryModel>> GetPolicyList(int roleId, CancellationToken cancellationToken)
    {
        return await _repository.GetPolicyList(roleId, cancellationToken);
    }


}
