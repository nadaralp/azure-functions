using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FunctionApp2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FunctionApp2
{
    /// <summary>
    /// This function is an example of using Dependency Injection (IOC Container)
    /// </summary>
    public class Function1
    {
        private readonly ITestService _testService;
        private readonly IOptions<OptionsPattern> _options;

        public Function1(ITestService testService, IOptions<OptionsPattern> options)
        {
            _testService = testService;
            _options = options;
        }

        [FunctionName("amazingFunctionEu")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            StringBuilder response = new StringBuilder();
            response.Append(_options.Value.Prop1);
            response.Append("\n");
            response.Append(_options.Value.Prop2);
            response.Append("\n");
            response.Append(_testService.DoSomething());
            
            return new OkObjectResult(response.ToString());
        }
    }
}
