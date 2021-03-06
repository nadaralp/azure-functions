using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FunctionApp1.MockService;

namespace FunctionApp1
{
    public static class ThirdAmazingFn
    {
        [FunctionName("ThirdAmazingFn")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("processing amazing function");

            var service = new ErrorService();
            service.DoStuff();

            return new OkResult();
        }
    }
}
