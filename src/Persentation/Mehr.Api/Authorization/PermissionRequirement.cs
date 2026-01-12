using Mehr.Application.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Mehr.Api.Authorization;

public class PermissionRequirement : IAuthorizationRequirement
{
    public IEnumerable<string> Permissions { get; }
    public PermissionRequirement(IEnumerable<string> permissions) => Permissions = permissions;
}
//


public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        var userPermissions = context.User.Claims
            .Where(c => c.Type == CustomClaimTypes.Permission)
            .Select(c => c.Value);

        if (requirement.Permissions.Any(p => userPermissions.Contains(p)))
        {
            context.Succeed(requirement);
        }
        return Task.CompletedTask;
    }
}

// Web/Authorization/PermissionPolicyProvider.cs
public class PermissionPolicyProvider : DefaultAuthorizationPolicyProvider
{
    public PermissionPolicyProvider(IOptions<AuthorizationOptions> options) : base(options) { }

    public override async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        var policy = await base.GetPolicyAsync(policyName);
        if (policy != null) return policy;

        var permissions = policyName.Split(',');
        return new AuthorizationPolicyBuilder()
            .AddRequirements(new PermissionRequirement(permissions))
            .Build();
    }
}

public class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(params string[] permissions)
        : base(policy: string.Join(",", permissions)) { }
}
