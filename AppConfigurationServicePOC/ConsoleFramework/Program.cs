using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using System;
using System.Threading.Tasks;

namespace ConsoleFramework
{
    class Program
    {
        private static IConfiguration _configuration = null;

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.AddAzureAppConfiguration(options => options.ConnectWithManagedIdentity("https://callcenterpoc.azconfig.io"));
            _configuration = builder.Build();
            Console.WriteLine(_configuration["MyPassword"] ?? "Not here");
            Console.ReadLine();
        }

    }
}
