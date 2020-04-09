using Microsoft.Extensions.Configuration;
using System;
using Azure.Identity;
using System.IO;

namespace AppConfigurationServicePOC
{
    class Program
    {
        private static IConfigurationRoot Configuration;

        static void Main()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            var appConfigServiceConnection = Configuration["AppConfigServiceEndpoint:Endpoint"];
            builder.AddAzureAppConfiguration(options => options.ConnectWithManagedIdentity(appConfigServiceConnection));

            Configuration = builder.Build();
            Console.WriteLine(Configuration["MyPassword"] ?? "Not here");
            Console.ReadLine();
        }
    }
}
