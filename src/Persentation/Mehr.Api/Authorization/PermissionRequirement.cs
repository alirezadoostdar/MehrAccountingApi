using Mehr.Application.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Mehr.Api.Authorization;

public class PermissionRequirement : IAuthorizationRequirement
{
    public PermissionCheckMode Mode { get; }
    public IReadOnlyList<string> Permissions { get; }

    public PermissionRequirement(
        PermissionCheckMode mode,
        IReadOnlyList<string> permissions)
    {
        Mode = mode;
        Permissions = permissions;
    }
}
//


public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {

        var userPermissions = context.User.Claims
                    .Where(c => c.Type == CustomClaimTypes.Permission)
                    .Select(c => c.Value)
                    .ToHashSet();

        bool isAuthorized = requirement.Mode switch
        {
            PermissionCheckMode.All =>
                requirement.Permissions.All(p => userPermissions.Contains(p)),

            PermissionCheckMode.Any =>
                requirement.Permissions.Any(p => userPermissions.Contains(p)),

            _ => false
        };

        if (isAuthorized)
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}

// Web/Authorization/PermissionPolicyProvider.cs
public class PermissionPolicyProvider : DefaultAuthorizationPolicyProvider
{
    private const string POLICY_PREFIX = "permission.";

    public PermissionPolicyProvider(
        IOptions<AuthorizationOptions> options)
        : base(options)
    {
    }

    public override Task<AuthorizationPolicy?> GetPolicyAsync(
        string policyName)
    {
        if (!policyName.StartsWith("Permission:"))
            return base.GetPolicyAsync(policyName);

        // Permission:All:InvoiceCreate,InvoiceEdit
        var parts = policyName.Split(':');
        var mode = Enum.Parse<PermissionCheckMode>(parts[1]);
        var permissions = parts[2].Split(',').ToList();

        var policy = new AuthorizationPolicyBuilder()
            .AddRequirements(new PermissionRequirement(mode, permissions))
            .Build();

        return Task.FromResult<AuthorizationPolicy?>(policy);
    }
}

public class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(
        PermissionCheckMode mode,
        params MehrPolicy[] policies)
    {
        if (policies == null || policies.Length == 0)
            throw new ArgumentNullException("At least one permission is required");

        var policiesNames = policies.Select(p => ((int)p).ToString());
        var joined = string.Join(",", policiesNames);

        Policy = $"Permission:{mode}:{joined}";
    }

    public HasPermissionAttribute(params MehrPolicy[] policies)
        :this (PermissionCheckMode.All, policies)
    {
    }
}

public enum PermissionCheckMode
{
    All,
    Any
}
