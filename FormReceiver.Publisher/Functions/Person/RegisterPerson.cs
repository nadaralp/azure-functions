using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PubSubDemo.Core.Services;
using System.IO;
using PubSubDemo.Core.Entities;
using System.Text.Json;
using System;

namespace FormReceiver.Publisher.Functions
{
    public class RegisterPerson
    {
        private readonly IPersonService _personService;

        public RegisterPerson(IPersonService personService)
        {
            _personService = personService;
        }


        [FunctionName("RegisterPerson")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, methods: "post", Route = null)] HttpRequest req,
            [Queue("newly-registered"), StorageAccount("AzureWebJobsStorage")] ICollector<string> queue,
            ILogger log)
        {
            try
            {
                string payload = await new StreamReader(req.Body).ReadToEndAsync();
                //Person person = JsonSerializer.Deserialize<Person>(payload, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true});
                Person person = JsonSerializer.Deserialize<Person>(payload);

                int rowId = await _personService.Add(person);
                log.LogInformation("person was added successfully");

                queue.Add(rowId.ToString());

                return new OkObjectResult(person);
            }

            catch (Exception e)
            {
                return new BadRequestObjectResult(e);
            }



        }
    }
}
