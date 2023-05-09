using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WinApp.Svl
{
    public class ServiceConnection : IServiceConnection
    {
        public HttpClient HttpEnabler { private get; init; }
        public string? BaseUrl { get; init; }
        public string? UseUrl { get; set; }
        public ServiceConnection(String inBaseUrl)
        {
            HttpEnabler = new HttpClient();
            BaseUrl = inBaseUrl;
            UseUrl = BaseUrl;
        }

        public async Task<HttpResponseMessage?> CallServicePost(string endpoint, StringContent postData)
        {
            HttpResponseMessage? response = null;
            try
            {
                response = await HttpEnabler.PostAsync(endpoint, postData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
            return response;
        }


        public Task<HttpResponseMessage?> CallServiceGet()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage?> CallServicePut(StringContent postJson)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage?> CallServiceDelete()
        {
            throw new NotImplementedException();
        }

    }
}
