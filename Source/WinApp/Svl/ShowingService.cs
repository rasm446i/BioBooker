using BioBooker.WebApi.Ctl.Controllers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBooker.WinApp.Svl
{
    public class ShowingService : IShowingService
    {
        private readonly IServiceConnection _serviceConnection;
        readonly string _serviceBaseUrl = "https://localhost:7011/";
        //Showing Controller

        public ShowingService(IConfiguration configuration) 
        { 
        
        
        }
    }
}
