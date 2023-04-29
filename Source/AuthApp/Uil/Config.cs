using Duende.IdentityServer.Models;
using System.Collections.Generic;

namespace BioBooker.AuthApp.Uil;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
    {
        new IdentityResources.OpenId()
    };

    public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
    {
        new ApiScope(name: "WebApi.FullCrudScope", displayName: "WebApi.FullCrudScope")
    };

    public static IEnumerable<Client> Clients => new Client[]
    {
        new Client
        {
            ClientId = "WinApp",
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            ClientSecrets =
            {
                new Secret("authclientsecret".Sha256())
            },
            AllowedScopes = { "WebApi.FullCrudScope" }
        }
    };
}
