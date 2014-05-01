using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;

namespace AzureCors
{
    public class CorsConfigurator
    {
        private readonly CorsConfigurationMessage corsConfig;

        public CorsConfigurator(CorsConfigurationMessage corsMessage)
        {
            this.corsConfig = corsMessage;
        }

        public void EnableBlobCors()
        {
            var cred = new StorageCredentials(corsConfig.AccountName, corsConfig.AccountKey);
            var storageAccount = new CloudStorageAccount(cred, true);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var serviceProperties = ConfigureCors(blobClient);
            blobClient.SetServiceProperties(serviceProperties);
        }

        private ServiceProperties ConfigureCors(CloudBlobClient blobClient)
        {
            var serviceProperties = new ServiceProperties
            {
                HourMetrics = null,
                MinuteMetrics = null,
                Logging = null
            };

            AddCorsRule(serviceProperties);
            return serviceProperties;
        }

        private void AddCorsRule(ServiceProperties serviceProperties)
        {
            serviceProperties.Cors = new CorsProperties();
            serviceProperties.Cors.CorsRules.Add(new CorsRule()
            {
                AllowedHeaders = this.corsConfig.AllowedHeaders,
                AllowedMethods = this.corsConfig.Verbs,
                AllowedOrigins = this.corsConfig.AllowedOrigins,
                ExposedHeaders = this.corsConfig.ExposedHeaders,
                MaxAgeInSeconds = this.corsConfig.MaxAge
            });
        }
    }
}