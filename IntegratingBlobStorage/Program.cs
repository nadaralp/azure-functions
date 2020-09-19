using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace IntegratingBlobStorage
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Get a value from envrioment variable
            var connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
            Console.WriteLine(connectionString);

            // Opening a new blob service client
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            string containerName = Guid.NewGuid().ToString();

            var res = await blobServiceClient.CreateBlobContainerAsync(containerName, publicAccessType: PublicAccessType.BlobContainer);
            Console.WriteLine(res);

            // the blob container client - used for interacting with the container like uploading blob, deleting, etc..
            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);



            // Create a file in the system
            string localPath = "./";
            string fileName = "demo.txt";
            string localFilePath = Path.Combine(localPath, fileName);

            // Write to file
            await File.WriteAllTextAsync(localFilePath, "Hello world from demo \nthis is anamzing ag egerg arg ");
            

            for (int i = 0; i < 5; i++)
            {
                FileStream fileStream = File.OpenRead(localFilePath);
                await blobContainerClient.UploadBlobAsync(Guid.NewGuid().ToString() +  ".txt", fileStream);
                await fileStream.DisposeAsync();
            }

            Console.WriteLine("Blob was written successfully.");


            // Gettings blobs from container
            var blobs =  blobContainerClient.GetBlobsAsync();
            await foreach (BlobItem blob in blobs)
            {
                Console.WriteLine(blob.Name);

                BlobClient blobClient = blobContainerClient.GetBlobClient(blob.Name);

                // Downloading the blobs
                var downloadPath = Path.Combine("./", Guid.NewGuid().ToString() + ".txt");
                await blobClient.DownloadToAsync(downloadPath);

                // Reading the blobs
                using (Stream stream = await blobClient.OpenReadAsync())
                using (StreamReader sr = new StreamReader(stream))
                {
                    string s;
                    while ((s = await sr.ReadLineAsync()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }

            

            // Downloading the blobs

            Console.WriteLine("To delete enter a key");
            Console.ReadLine();

            Console.WriteLine("Deleting " + blobContainerClient.Name + " ....");
            await blobContainerClient.DeleteAsync();
            Console.WriteLine("deleted successfully");

        }
    }
}
