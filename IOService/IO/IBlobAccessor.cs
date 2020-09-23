using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOService.IO
{
    public interface IBlobAccessor
    {
        BlobServiceClient GetBlobServiceClient(string connectionString);
        BlobContainerClient GetBlobContainerClient(string containerName);
    }
}
