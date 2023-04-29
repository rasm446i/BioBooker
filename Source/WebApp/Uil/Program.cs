using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BioBooker.WebApp.Uil;

internal static class Program
{
    internal static void Main(string[] args)
    {
        var webAppBuilder = WebApplication.CreateBuilder(args);
        webAppBuilder.Services.AddControllersWithViews();

        var webApp = webAppBuilder.Build();
        webApp.UseStaticFiles();
        webApp.UseRouting();
        webApp.UseAuthorization();
        webApp.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
        webApp.Run();
    }
}
