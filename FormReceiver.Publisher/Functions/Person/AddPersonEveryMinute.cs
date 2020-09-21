using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using PubSubDemo.Core.Entities;
using PubSubDemo.Core.Services;
using PubSubDemo.Infrastructure.Utils;

namespace FormReceiver.Publisher.Functions
{
    public class AddPersonEveryMinute
    {
        private readonly IPersonService _personService;
        private readonly NameGenerator _nameGenerator;

        public AddPersonEveryMinute(IPersonService personService, NameGenerator nameGenerator)
        {
            _personService = personService;
            _nameGenerator = nameGenerator;
        }


        [FunctionName(nameof(AddPersonEveryMinute))]
        public void Run(
            [TimerTrigger("0 0/1 * 1/1 * *")]TimerInfo myTimer,
            ILogger log)
        {
            var random = new Random();
            var person = new Person()
            {
                Age = random.Next(18, 35),
                Name = _nameGenerator.GenerateName(),
                RegisterDare = DateTime.Now
            };

            log.LogInformation("Adding person....");
            _personService.Add(person);
            log.LogInformation("Person was added");
        }
    }
}
