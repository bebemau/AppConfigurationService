using Microsoft.Extensions.Configuration;
using System;
using m = System.Configuration;

namespace ConsoleFramework
{
    class Program
    {
        private static IConfiguration _configuration = null;

        static void Main(string[] args)
        {
            var location = m.ConfigurationManager.AppSettings["AppConfigurationServiceLocation"];
            var builder = new ConfigurationBuilder();
            builder.AddAzureAppConfiguration(options => options.ConnectWithManagedIdentity(location));
            _configuration = builder.Build();
            Console.WriteLine(_configuration["MyPassword"] ?? "Not here");
            Console.ReadLine();
        }



    }
}
