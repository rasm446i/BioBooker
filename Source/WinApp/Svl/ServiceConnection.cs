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

        public ServiceConnection(String inBaseUrl)
        {
            HttpEnabler = new HttpClient();
            BaseUrl = inBaseUrl;
            UseUrl = BaseUrl;
        }

        public HttpClient HttpEnabler { private get; init; }
        public string? BaseUrl { get; set; }
        public string? UseUrl { get; set; }


        public async Task<HttpResponseMessage?> CallServiceGet(string url)
        {
            HttpResponseMessage? hrm = null;
            if (url != null)
            {
                hrm = await HttpEnabler.GetAsync(url);
            }
            return hrm;
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

        public Task<HttpResponseMessage?> CallServicePut(StringContent postJson)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage?> CallServiceDelete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
