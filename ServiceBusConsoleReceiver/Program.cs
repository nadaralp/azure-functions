using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.InteropExtensions;
using ServiceBus.model;
using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceBusConsoleReceiver
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("bus receiver app");

            // Manage connectionString
            // string serviceBusConnectionString = "Endpoint=sb://servicebus-demo-1231.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=9XO6OpkX5WBd+mqB3xci574y7X0ppr+sKg4Q/UH5o2o=";

            // Reader connectionString
            string serviceBusConnectionString = "Endpoint=sb://servicebus-demo-1231.servicebus.windows.net/;SharedAccessKeyName=ReaderPolicy;SharedAccessKey=Yt9oAzZbJBuG3GWilLub/Cfxhimy5EsSLkGDiNf0ckU=";
            string queueName = "myq";

            IQueueClient queueClient = new QueueClient(serviceBusConnectionString, queueName, ReceiveMode.PeekLock);

            // Registering message handler
            var MessageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            // queueClient.ReceiveMode = ReceiveMode.ReceiveAndDelete;

            queueClient.RegisterMessageHandler(async (Message msg, CancellationToken cancelationToken) =>
            {
                Console.WriteLine(msg.SystemProperties.SequenceNumber + " ---> Sequence Number");
                Console.WriteLine(msg.SystemProperties.EnqueuedTimeUtc + " ---> Enqueued Time");
                Console.WriteLine(msg.ContentType + " ----> Content Type");
                Console.WriteLine(msg.SystemProperties.DeliveryCount + " -----> Delivery Count");
                Console.WriteLine(msg.ExpiresAtUtc + " -----> Expire time");
                Console.WriteLine(msg.SystemProperties.LockToken + " -----> Lock token");
                Console.WriteLine(msg.MessageId + " -----> message id");
                Console.WriteLine(msg.CorrelationId + " -----> correlation id");


                // var myMessage = msg.GetBody<Person>();
                // Console.WriteLine("received message: " + myMessage);

                using (var bodyStream = new MemoryStream(msg.Body))
                using (var sr = new StreamReader(bodyStream))
                {
                    string body = await sr.ReadToEndAsync();
                    Person entity = JsonSerializer.Deserialize<Person>(body);
                    Console.WriteLine("body from message is: " + body);
                }

                // acknowledge and release the message from the queue
                await queueClient.CompleteAsync(msg.SystemProperties.LockToken);


                // queueClient.AbandonAsync; // Releases the lock
                //queueClient.DeadLetterAsync(msg.SystemProperties.LockToken); -> knowing that retry won't help. you can deadletter the message

            }, MessageHandlerOptions);

            

            Console.ReadLine();
        }

        static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            Console.WriteLine($"Message handler encountered an exception {exceptionReceivedEventArgs.Exception}.");
            var context = exceptionReceivedEventArgs.ExceptionReceivedContext;
            Console.WriteLine("Exception context for troubleshooting:");
            Console.WriteLine($"- Endpoint: {context.Endpoint}");
            Console.WriteLine($"- Entity Path: {context.EntityPath}");
            Console.WriteLine($"- Executing Action: {context.Action}");
            return Task.CompletedTask;
        }
    }
}
