using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;

namespace AzureCors
{
    public class CorsConfigurationMessage
    {
        public string AccountName { get; set; }
        public string AccountKey { get; set; }
        public int MaxAge { get; set; }
        public CorsHttpMethods Verbs { get; set; }
        public IList<string> AllowedHeaders { get; set; }
        public IList<string> AllowedOrigins { get; set; }
        public IList<string> ExposedHeaders { get; set; }
    }
}