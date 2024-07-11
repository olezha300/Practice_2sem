using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Report.Identity;

public static class Configuration
{
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("ReportsWebAPI", "Web API")
        };

    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

    public static IEnumerable<ApiResource> ApiResources =>
        new List<ApiResource>
        {
            new ApiResource("ReportsWebAPI", "Web API", new []
                { JwtClaimTypes.Name})
            {
                Scopes = {"ReportsWebAPI"}
            }
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId = "reports-web-app",
                ClientName = "Reports Web",
                AllowedGrantTypes = GrantTypes.Code,
                RequireClientSecret = false,
                RequirePkce = true,
                RedirectUris =
                {
                    "http://localhost:3000/signin-oidc"
                },
                AllowedCorsOrigins =
                {
                    "http://localhost:3000"
                },
                PostLogoutRedirectUris =
                {
                    "http://localhost:3000/signout-oidc"
                },
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "ReportsWebAPI"
                },
                AllowAccessTokensViaBrowser = true
            }
        };
}