using BioBooker.AuthApp.Uil.Data.Migrations.AspNetCoreIdentity;
using Microsoft.AspNetCore.Builder;
using Serilog;
using System;

namespace BioBooker.AuthApp.Uil;

internal static class Program
{
    internal static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateBootstrapLogger();

        Log.Information("Starting ...");

        try
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{Newline}{Exception}{Newline}").Enrich.FromLogContext().ReadFrom.Configuration(ctx.Configuration));

            var app = builder.ConfigureServices().ConfigurePipeline();

            //Log.Information("Seeding Database!");
            //SeedData.EnsureSeedData(app);
            //Log.Information("Database Seeded!");

            app.Run();
        }
        catch (Exception e) when
        (
            e.GetType().Name is not "StopTheHostException"
            &&
            e.GetType().Name is not "HostAbortedException"
        )
        {
            Log.Fatal(e, "Unhandled Exception!");
        }
        finally
        {
            Log.Information("Shutting Down ...");
            Log.CloseAndFlush();
        }
    }
}
