using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;

namespace BioBooker.WebApp.Uil;

internal static class Program
{
    internal static void Main(string[] args)
    {
        var webAppBuilder = WebApplication.CreateBuilder(args);

        JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
        webAppBuilder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")
            // Use Authorization Code Flow with PKCE to Connect to the OpenID Connect Provider
            .AddOpenIdConnect("oidc", options =>// Perform OpenID Connect Protocol
            {
                options.Authority = "https://localhost:7001";// Trusted Token Service/Provider
                options.ClientId = "WebApp";// Id Client Part 1
                options.ClientSecret = "authclientsecret"; // Id Client Part 2
                options.ResponseType = "code";//

                options.SaveTokens = true;// Persist id, access token, and refresh token from IdentityServer in Cookie
                options.Scope.Clear();

                options.Scope.Add("openid");
                options.Scope.Add("profile");
                options.Scope.Add("WebApi.FullCrudScope");
                options.Scope.Add("offline_access");
                options.Scope.Add("verification");// Add Custom Claim
                options.ClaimActions.MapJsonKey("email_verified", "email_verified");// Map Custom Claim from UserInfoEndpoint to a User Object Claim
                options.GetClaimsFromUserInfoEndpoint = true;
            });

        webAppBuilder.Services.AddControllersWithViews();

        var webApp = webAppBuilder.Build();
        webApp.UseStaticFiles();
        webApp.UseRouting();
        webApp.UseAuthentication();
        webApp.UseAuthorization();
        webApp.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute().RequireAuthorization();
        });
        //webApp.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
        webApp.Run();
    }
}
