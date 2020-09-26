using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceBus.model;
using System.Text.Json;

namespace ServiceBusConsoleApp
{
    public class QueueService
    {
        public async Task SendMessagesToQueue()
        {
            try
            {
                // This is a manager connection string
                // string serviceBusConnectionString = "Endpoint=sb://servicebus-demo-1231.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=9XO6OpkX5WBd+mqB3xci574y7X0ppr+sKg4Q/UH5o2o=";

                // reader connectionString
                // string serviceBusConnectionString = "Endpoint=sb://servicebus-demo-1231.servicebus.windows.net/;SharedAccessKeyName=ReaderPolicy;SharedAccessKey=Yt9oAzZbJBuG3GWilLub/Cfxhimy5EsSLkGDiNf0ckU=";

                // sender connectionString 
                string serviceBusConnectionString = "Endpoint=sb://servicebus-demo-1231.servicebus.windows.net/;SharedAccessKeyName=SenderPolicy;SharedAccessKey=O55ukmjrJoaLylEDS83JWfQ8aP6qON3jXdONgrd7XRE=";
                string queueName = "myq";
                IQueueClient queueClient = new QueueClient(serviceBusConnectionString, queueName);

                var Person = new Person
                {
                    Name = "Nadar",
                    Age = 22
                };

                string msg = JsonSerializer.Serialize(Person);
                Message message = new Message(Encoding.UTF8.GetBytes(msg));
                // message.Label = "I cant set the label for the receiving message";
                message.TimeToLive = TimeSpan.FromHours(2);
                message.ContentType = "application/json;charset=utf-8";

                Console.WriteLine("sending message...");
                await queueClient.SendAsync(message);

                Console.WriteLine("message sent...");

                await queueClient.CloseAsync();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                throw;
            }


        }
    }
}
