using ExpressDesk360.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace ExpressDesk360.Core.Utils.Auth;

/// <summary>
/// Role names as persisted in the Roles table. Kept in sync with <see cref="RoleType"/> and the seed data in AppDbContext.
/// </summary>
public static class Roles
{
    public const string User = nameof(RoleType.User);
    public const string Manager = nameof(RoleType.Manager);
    public const string Admin = nameof(RoleType.Admin);
    public const string Owner = nameof(RoleType.Owner);

    public static readonly string[] All = { User, Manager, Admin, Owner };
}

/// <summary>
/// Named authorization policies. Each policy is cumulative: higher roles satisfy lower policies.
/// </summary>
public static class Policies
{
    /// <summary>Any authenticated user.</summary>
    public const string User = "policy_user";

    /// <summary>Manager and above.</summary>
    public const string Manager = "policy_manager";

    /// <summary>Admin and above.</summary>
    public const string Admin = "policy_admin";

    /// <summary>Owner only.</summary>
    public const string Owner = "policy_owner";
}

public static class AuthorizationRegistration
{
    /// <summary>
    /// Registers the role policies and a fallback policy that requires authentication on every
    /// endpoint. Endpoints that must stay public have to opt out with [AllowAnonymous].
    /// </summary>
    public static IServiceCollection AddAppAuthorization(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy(Policies.User, p => p.RequireRole(Roles.User, Roles.Manager, Roles.Admin, Roles.Owner));
            options.AddPolicy(Policies.Manager, p => p.RequireRole(Roles.Manager, Roles.Admin, Roles.Owner));
            options.AddPolicy(Policies.Admin, p => p.RequireRole(Roles.Admin, Roles.Owner));
            options.AddPolicy(Policies.Owner, p => p.RequireRole(Roles.Owner));

            // Secure by default: anything without an explicit attribute still requires a signed-in user.
            options.FallbackPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
        });

        return services;
    }
}
