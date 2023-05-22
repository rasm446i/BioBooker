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

        /// <summary>
        /// Calls an API service endpoint using the HTTP GET method.
        /// </summary>
        /// <param name="url">The URL of the service endpoint to be called.</param>
        /// <returns>
        /// A task that holds an HttpResponseMessage or null if the URL is null.
        /// </returns>
        public async Task<HttpResponseMessage?> CallServiceGet(string url)
        {
            HttpResponseMessage? hrm = null;
            if (url != null)
            {
                hrm = await HttpEnabler.GetAsync(url);
            }
            return hrm;
        }

        /// <summary>
        /// Calls the API service endpoint using the HTTP POST method and sends the provided data.
        /// </summary>
        /// <param name="endpoint">The URL endpoint of the service.</param>
        /// <param name="postData">The content to be sent in the request body.</param>
        /// <returns>
        /// A task that holds an HttpResponseMessage or null if an exception occurs during the request.
        /// </returns>
        public async Task<HttpResponseMessage?> CallServicePost(string endpoint, StringContent postData)
        {
            HttpResponseMessage? response = null;
            try
            {
                response = await HttpEnabler.PostAsync(endpoint, postData);
            }
            catch (Exception ex)
            {
                throw;
            }
            return response;
        }

        /// <summary>
        /// Calls an API service endpoint using the HTTP PUT method and sends the provided data.
        /// </summary>
        /// <param name="url">The URL of the service endpoint to be called.</param>
        /// <param name="putData">The content to be sent in the request body.</param>
        /// <returns>
        /// A task that holds an HttpResponseMessage or null if the URL is null.
        /// </returns>
        public async Task<HttpResponseMessage?> CallServicePut(string url, StringContent putData)
        {
            HttpResponseMessage? hrm = null;
            if (url != null)
            {
                hrm = await HttpEnabler.PutAsync(url, putData);
            }
            return hrm;
        }

        /// <summary>
        /// Calls an API service endpoint using the HTTP DELETE method.
        /// </summary>
        /// <param name="url">The URL of the service endpoint to be called.</param>
        /// <param name="id">The ID parameter for the delete request.</param>
        /// <returns>
        /// A task that holds an HttpResponseMessage or null if the URL is null.
        /// </returns>
        public async Task<HttpResponseMessage?> CallServiceDelete(string url, int id)
        {
            HttpResponseMessage? hrm = null;
            if(url != null)
            {
                hrm = await HttpEnabler.DeleteAsync(url);
            }
            return hrm;
        }

    }
}
