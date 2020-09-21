using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PubSubDemo.Core.Services;

namespace FormReceiver.Publisher.Functions
{
    public class ListAllPeople
    {
        private readonly IPersonService _personService;

        public ListAllPeople(IPersonService personService)
        {
            _personService = personService;
        }


        [FunctionName("ListAllPeople")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {   
            try
            {
                return new OkObjectResult(await _personService.GetAll());
            }
            catch(Exception e)
            {
                return new BadRequestObjectResult(e);
            }
            
        }
    }
}
