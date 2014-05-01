
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;

namespace AzureCors
{
    class Program
    {
        static void Main(string[] args)
        {
            var corsConfigurator = new CorsConfigurator(new CorsConfigurationMessage
            {
                AccountName = "", // Storage Account Key
                AccountKey = "", // Storage Account Name
                AllowedOrigins = new List<string>() {"*"},
                AllowedHeaders = new List<string>() {"*"},
                ExposedHeaders = new List<string>() {"*"},
                MaxAge = 1800, // 30 minutes
                Verbs =
                    CorsHttpMethods.Put | CorsHttpMethods.Get | CorsHttpMethods.Head | CorsHttpMethods.Post |
                    CorsHttpMethods.Options
            });

            corsConfigurator.EnableBlobCors();
        }
    }
}
