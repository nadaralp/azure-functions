using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using SendGridMailService;

namespace EmailSenderFunctionService
{
    public class SendEmailOnRegisterFunction
    {

        private readonly MailService mailService = new MailService();

        [FunctionName("SendEmailOnRegisterFunction")]
        public async Task Run(
            [QueueTrigger("newly-registered"), StorageAccount("AzureWebJobsStorage")] string myQueueItem,
            ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
            log.LogInformation("Starting to send email...");
            await mailService.SendMail("");
            log.LogInformation("Email sent");
            
        }
    }
}
