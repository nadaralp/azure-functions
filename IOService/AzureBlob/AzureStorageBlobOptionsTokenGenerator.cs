using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;

namespace IOService.AzureBlob
{
    // This is an old API (v11 SDK.). 
    // There is a V12 sdk available.
    public class AzureStorageBlobOptionsTokenGenerator
    {
        private readonly IOptions<AzureStorageBlobOptions> _options;

        public AzureStorageBlobOptionsTokenGenerator(IOptions<AzureStorageBlobOptions> options)
        {
            _options = options;
        }

        public string GenerateSasToken(string containerName)
        {
            return GenerateSasToken(containerName, DateTime.Now.AddMinutes(1));
        }

        public string GenerateSasToken(string containerName, DateTime expiresOn)
        {
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(_options.Value.ConnectionString);
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(containerName);

            SharedAccessBlobPermissions permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write;

            string sasContainerToken;

            SharedAccessBlobPolicy shareAccessBlobPolicy =
                new SharedAccessBlobPolicy()
                {
                    SharedAccessStartTime = DateTime.UtcNow.AddMinutes(-5),
                    SharedAccessExpiryTime = expiresOn,
                    Permissions = permissions
                };

            sasContainerToken = cloudBlobContainer.GetSharedAccessSignature(shareAccessBlobPolicy, null);

            return sasContainerToken;
        }
    }
}
