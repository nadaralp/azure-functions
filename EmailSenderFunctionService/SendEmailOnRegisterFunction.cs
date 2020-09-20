using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace EmailSenderFunctionService
{
    public static class SendEmailOnRegisterFunction
    {
        [FunctionName("SendEmailOnRegisterFunction")]
        public static void Run(
            [QueueTrigger("newly-registered"), StorageAccount("AzureWebJobsStorage")] string myQueueItem,
            ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
