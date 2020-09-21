using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace BlobFileReaderService.Functions
{
    public class ExcelReader
    {
        [FunctionName("ExcelReader")]
        public void Run(
            [BlobTrigger("excel-data/{name}.{extension}", Connection = "AzureWebJobsStorage")]Stream myBlob,
            string name,
            string extension,
            ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
            log.LogInformation($"file extension is {extension}");
        }
    }
}
