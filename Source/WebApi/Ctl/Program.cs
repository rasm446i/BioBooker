using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BioBooker.WebApi.Ctl;

internal static class Program
{
    internal static void Main(string[] args)
    {
        var webApiBuilder = WebApplication.CreateBuilder(args);
        webApiBuilder.Services.AddControllers();

        // CORS
        webApiBuilder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        // Authentication
        webApiBuilder.Services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.Authority = "https://localhost:7001/";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false
                };
            });

        // Authorization
        webApiBuilder.Services.AddAuthorization(options =>
            options.AddPolicy("RequireSpecificApiScopePolicy", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim("scope", "WebApi.FullCrudScope");
            })
        );

        var webApi = webApiBuilder.Build();
        webApi.UseHttpsRedirection();
        webApi.UseCors(); // Add this line to enable CORS
        webApi.UseAuthentication();
        webApi.UseAuthorization();
        webApi.MapControllers().RequireAuthorization("RequireSpecificApiScopePolicy");
        webApi.Run();
    }
}