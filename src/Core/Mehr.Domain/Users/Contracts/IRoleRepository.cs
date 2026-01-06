namespace Mehr.Domain.Users.Contracts;

public interface IRoleRepository
{
    Task<List<RolePolicy_QueryModel>> GetPolicyList(int roleId, CancellationToken cancellationToken);
}
