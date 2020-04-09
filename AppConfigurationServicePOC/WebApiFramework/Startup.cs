using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.Owin;
using Owin;
using System;
using m = System.Configuration;


[assembly: OwinStartup(typeof(WebApiFramework.Startup))]

namespace WebApiFramework
{
    public class Startup
    {
        internal static IConfiguration _Configuration { get; private set; }

        public Startup()
        {
            var location = m.ConfigurationManager.AppSettings["AppConfigurationStoreLocation"];
            var builder = new ConfigurationBuilder();
            builder.AddAzureAppConfiguration(options => options.ConnectWithManagedIdentity(location));
            _Configuration = builder.Build();
        }

        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
