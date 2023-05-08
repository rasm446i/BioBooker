using BioBooker.WinApp.Uil.Views;
using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace BioBooker.WinApp.Uil;

internal static class Program
{
    [STAThread]
    internal static void Main(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        Auth();
        ApplicationConfiguration.Initialize();
        Application.Run(new HomeView(configuration));
    }

    public static async void Auth()
    {
        var client = new HttpClient();
        var discoveryDocument = await client.GetDiscoveryDocumentAsync("https://localhost:7001");

        if (discoveryDocument.IsError)
        {
            //MessageBox.Show(discoveryDocument.Error);
            return;
        }

        // Request Token from AuthApp to Access WebApi
        var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
        {
            Address = discoveryDocument.TokenEndpoint,
            ClientId = "WinApp",
            ClientSecret = "authclientsecret",
            Scope = "WebApi.FullCrudScope"
        }
        );

        if (tokenResponse.IsError)
        {
            //MessageBox.Show(tokenResponse.Error);
            return;
        }

        // Post Token to jwt.io to See Content of It
        //MessageBox.Show(tokenResponse.AccessToken);

        // Call API (Set HTTP Authorization Header)
        var apiClient = new HttpClient();
        apiClient.SetBearerToken(tokenResponse.AccessToken);

        var response = await apiClient.GetAsync("https://localhost:7011/identity");

        if (!response.IsSuccessStatusCode)
        {
            //MessageBox.Show(response.StatusCode.ToString());
        }
        else
        {
            var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;

           //MessageBox.Show(JsonSerializer.Serialize(doc, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}
