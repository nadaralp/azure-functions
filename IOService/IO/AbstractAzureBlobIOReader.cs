using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOService.IO
{
    public abstract class AbstractAzureBlobIOReader<T> : AbstractFileIOService<T>, IBlobAccessor where T : new()
    {
        private string connectionString;
        public BlobContainerClient GetBlobContainerClient(string containerName)
         => GetBlobServiceClient(connectionString).GetBlobContainerClient(containerName);

        public BlobServiceClient GetBlobServiceClient(string connectionString)
        {
            this.connectionString = connectionString;
            return new BlobServiceClient(connectionString);
        }
    }
}
