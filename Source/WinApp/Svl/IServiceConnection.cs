using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WinApp.Svl
{
    public interface IServiceConnection
    {
        public string? BaseUrl { get; set; }
        public string? UseUrl { get; set; }

        Task<HttpResponseMessage?> CallServiceGet(string url);
        Task<HttpResponseMessage?> CallServicePost(string url, StringContent postJson);
        Task<HttpResponseMessage?> CallServiceDelete(string url, int id);
        Task<HttpResponseMessage?> CallServicePut(string url, StringContent putData);

    }
}
