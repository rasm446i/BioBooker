using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Linq;
using System.Reflection;
using BioBooker.AuthApp.Uil.Data;
using BioBooker.AuthApp.Uil.Data.Migrations;
using BioBooker.AuthApp.Uil.Data.Migrations.AspNetCoreIdentity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;

namespace BioBooker.AuthApp.Uil;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        var migrationsAssembly = typeof(Program).Assembly.GetName().Name;
        const string connectString = "Server=PC\\SQLSERVERDEV;Database=AuthDbIdentityServer;User=sa;Password=Password1!;Encrypt=True;TrustServerCertificate=True;Trusted_Connection=SSPI;MultipleActiveResultSets=True";

        var connectionString = builder.Configuration.GetConnectionString("ConnectionString") ?? throw new InvalidOperationException("Connection String Not Found!");

        builder.Services.AddRazorPages();

        builder.Services.AddDbContext<AuthDbContext>(options =>
            options.UseSqlServer(connectionString));

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AuthDbContext>()
            .AddDefaultTokenProviders();// Email Link Token

        builder.Services.AddIdentityServer(options =>
        {
            options.Events.RaiseErrorEvents = true;
            options.Events.RaiseInformationEvents = true;
            options.Events.RaiseFailureEvents = true;
            options.Events.RaiseSuccessEvents = true;
            options.EmitStaticAudienceClaim = true;
        }
        )
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = b => b.UseSqlServer(connectString, sql => sql.MigrationsAssembly(migrationsAssembly));
            })
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = b => b.UseSqlServer(connectString, sql => sql.MigrationsAssembly(migrationsAssembly));
            })
            //.AddTestUsers(TestUsers.Users);
            //.AddInMemoryIdentityResources(Config.IdentityResources)
            //.AddInMemoryApiScopes(Config.ApiScopes)
            //.AddInMemoryClients(Config.Clients);
            .AddAspNetIdentity<ApplicationUser>();

        builder.Services.AddAuthentication();

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseStaticFiles();
        app.UseRouting();
        app.UseIdentityServer();
        app.UseAuthorization();
        app.MapRazorPages().RequireAuthorization();

        return app;
    }
}
