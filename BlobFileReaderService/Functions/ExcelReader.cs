using System;
using System.IO;
using IOService.IO;
using IOService.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace BlobFileReaderService.Functions
{
    public class ExcelReader
    {
        private readonly IFileIOService<SampleData> _fileIOService;

        public ExcelReader(IFileIOService<SampleData> fileIOService)
        {
            _fileIOService = fileIOService;
        }


        [FunctionName("ExcelReader")]
        public void Run(
            [BlobTrigger("excel-data/{name}.{extension}", Connection = "AzureWebJobsStorage")]Stream myBlob,
            string name,
            string extension,
            ILogger log)
        {
            // Create a factory design pattern with the extension methods.

            _fileIOService
                .LoadFile($"{name}.{extension}")
                .GetData();

            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
            log.LogInformation($"file extension is {extension}");
        }
    }
}
