using Mehr.Application.Common.Contracts;
using Mehr.Application.Users;
using Mehr.Application.Users.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Mehr.Infarstructure.Identity;

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

public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    private readonly IRoleService _roleService;

    public PermissionAuthorizationHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        string? roleId = context.User.Claims.Where(x => x.Type == "GroupId")
            .SingleOrDefault()?
            .Value;
        //var userPermissions = context.User.Claims
        //            .Where(c => c.Type == CustomClaimTypes.Permission)
        //            .Select(c => c.Value)
        //            .ToHashSet();
        var userPermissions =  await _roleService.GetActivePolicyList(Convert.ToInt32(roleId),default);


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

        //return Task.CompletedTask;
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
        : this(PermissionCheckMode.All, policies)
    {
    }
}

public enum PermissionCheckMode
{
    All,
    Any
}
