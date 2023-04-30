using System.Security.Claims;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using BioBooker.AuthApp.Uil.Data.Migrations;
using Microsoft.AspNetCore.Builder;
using BioBooker.AuthApp.Uil.Data.Migrations.AspNetCoreIdentity;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace BioBooker.AuthApp.Uil.Data.Migrations.AspNetCoreIdentity;

public class SeedData
{
    public static void EnsureSeedData(WebApplication app)
    {
        using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var context = scope.ServiceProvider.GetService<AuthDbContext>();
            context.Database.Migrate();

            var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var userName01 = userMgr.FindByNameAsync("UserName01").Result;
            if (userName01 == null)
            {
                userName01 = new ApplicationUser
                {
                    UserName = "UserName01",
                    Email = "user01@email.com",
                    EmailConfirmed = true,
                };
                var result = userMgr.CreateAsync(userName01, "Pass123!").Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                result = userMgr.AddClaimsAsync(userName01, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "UserName01 Name"),
                            new Claim(JwtClaimTypes.GivenName, "UserName01 GivenName"),
                            new Claim(JwtClaimTypes.FamilyName, "UserName01 FamilyName"),
                            new Claim(JwtClaimTypes.WebSite, "http://username01.com"),
                        }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
                Log.Debug("userName01 created");
            }
            else
            {
                Log.Debug("userName01 already exists");
            }

            var userName02 = userMgr.FindByNameAsync("userName02").Result;
            if (userName02 == null)
            {
                userName02 = new ApplicationUser
                {
                    UserName = "UserName02",
                    Email = "user02@email.com",
                    EmailConfirmed = true
                };
                var result = userMgr.CreateAsync(userName02, "Pass123!").Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                result = userMgr.AddClaimsAsync(userName02, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "UserName02 Name"),
                            new Claim(JwtClaimTypes.GivenName, "UserName02 GivenName"),
                            new Claim(JwtClaimTypes.FamilyName, "UserName02 FamilyName"),
                            new Claim(JwtClaimTypes.WebSite, "http://username02.com"),
                            new Claim("location", "somewhere")
                        }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
                Log.Debug("userName02 created");
            }
            else
            {
                Log.Debug("userName02 already exists");
            }
        }
    }
}
