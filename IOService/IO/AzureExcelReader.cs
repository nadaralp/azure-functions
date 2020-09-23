using Azure.Storage.Blobs;
using ExcelDataReader;
using IOService.AzureBlob;
using IOService.IO;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOService
{
    public class AzureExcelReader<T> : IFileIOService<T> where T : new()
    {
        private readonly AzureStorageBlobOptionsTokenGenerator _optionsTokenGenerator;
        private readonly IOptions<AzureStorageBlobOptions> _options;

        public AzureExcelReader(AzureStorageBlobOptionsTokenGenerator optionsTokenGenerator, IOptions<AzureStorageBlobOptions> options)
        {
            _optionsTokenGenerator = optionsTokenGenerator;
            _options = options;
        }
        private string FilePath { get; set; }

        public async Task<IEnumerable<T>> GetData()
        {
            if (string.IsNullOrEmpty(FilePath))
                throw new InvalidOperationException($"filepath is empty for {nameof(AzureExcelReader<T>)}");


            string connectionString = _options.Value.ConnectionString;
            BlobServiceClient blobService = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = blobService.GetBlobContainerClient(_options.Value.ContainerName);

            BlobClient blobClient = containerClient.GetBlobClient(FilePath);
            Stream stream = await blobClient.OpenReadAsync();
            try
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {
                    do
                    {
                        while (reader.Read())
                        {
                            var country = reader["Country"].ToString();
                        }
                    } while (reader.NextResult());
                }
            }
            catch(Exception e)
            {

            }
            




            //using (FileStream stream = File.OpenRead(FilePath))
            //using(IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
            //{
            //    while (reader.Read())
            //    {
            //        Console.WriteLine("hello");
            //    }
            //}

            return null;
        }


        // Fluent Design Pattern
        public IFileIOService<T> LoadFile(string filePath)
        {
            FilePath = filePath;
            return this;
        }
    }
}