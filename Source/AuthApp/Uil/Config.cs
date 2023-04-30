using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;
using System.Collections.Generic;

namespace BioBooker.AuthApp.Uil;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
        // Added More Claims
        new IdentityResource()
        {
            Name = "verification",
            UserClaims = new List<string>
            {
                JwtClaimTypes.Email,
                JwtClaimTypes.EmailVerified
            }
        }
    };

    public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
    {
        new ApiScope(name: "WebApi.FullCrudScope", displayName: "WebApi.FullCrudScope")
    };

    public static IEnumerable<Client> Clients => new Client[]
    {
        // Machine to Machine Client (Like in WinApp)
        new Client
        {
            ClientId = "WinApp",
            ClientSecrets =
            {
                new Secret("authclientsecret".Sha256())
            },
            AllowedGrantTypes = GrantTypes.ClientCredentials, // Client Credentials Flow
            // Scopes the Machine Client Can Access
            AllowedScopes = { "WebApi.FullCrudScope" }
        },

        // Interactive ASP.NET Core Web App (Credentials Flow with Humans)
        new Client
        {
            ClientId = "WebApp",// + WebAppClient
            ClientSecrets =
            {
                new Secret("authclientsecret".Sha256())
            },
            AllowedGrantTypes = GrantTypes.Code, // Code Flow

            // Where to Redirect if Login Successful
            RedirectUris = { "https://localhost:7111/signin-oidc" },

            // Where to Redirect if Logout Successful
            PostLogoutRedirectUris = { "https://localhost:7111/signout-callback-oidc" },

            // Scopes the Machine Client Can Access
            AllowedScopes =
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                "verification"
            }
        }
    };
}
