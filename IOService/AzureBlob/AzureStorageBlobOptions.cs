using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOService.AzureBlob
{
    public class AzureStorageBlobOptions
    {
        public string ConnectionString { get; set; }
        public string ContainerName { get; set; }

        public AzureStorageBlobOptions()
        {
            ConnectionString = Environment.GetEnvironmentVariable($"{nameof(AzureStorageBlobOptions)}:{nameof(ConnectionString)}");
            ContainerName = Environment.GetEnvironmentVariable($"{nameof(AzureStorageBlobOptions)}:{nameof(ContainerName)}");
        }
    }
}
