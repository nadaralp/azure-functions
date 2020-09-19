using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IntegratingWithQueueStorage
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var storageConnectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");

            #region Inserting into queue

            Console.WriteLine("Starting queue creation...");
            var person = new PersonModel()
            {
                Name = "Nadar",
                Age = 22
            };

            // Getting a queue client
            QueueClient queueClient = new QueueClient(storageConnectionString, "myconsoleappqueue");

            // Create the queue
            await queueClient.CreateIfNotExistsAsync();

            Console.WriteLine("Queue created");

            // Send message to queue
            string message = "My First message into azure queue";
            if (await queueClient.ExistsAsync())
            {
                await queueClient.SendMessageAsync(message);
            }

            // Send object message to queue
            await queueClient.SendJsonSerializedMessageAsync(person);

            Console.WriteLine("messages sent successfully");

            // Peek queue
            PeekedMessage[] peekedMessage = await queueClient.PeekMessagesAsync();
            var firstMessage = peekedMessage[0];
            Console.WriteLine(firstMessage.MessageId + " Was inserted with the value of: " + firstMessage.MessageText);


            // Changing the contents of a message in place
            QueueMessage[] messages = await queueClient.ReceiveMessagesAsync();

            await queueClient.UpdateMessageAsync
                (messages[0].MessageId,
                 messages[0].PopReceipt,
                 "updated text",
                 TimeSpan.FromSeconds(60));

            Console.WriteLine("Updated message successfully");

            // In order to Ack a message you need to delete it
            // I'm calling receive messages again because the update manipulation changes the id of the message
            messages = await queueClient.ReceiveMessagesAsync();
            var messageToDelete = messages[0];
            Console.WriteLine(messageToDelete.MessageId + " Is being processed for deletion");
            Console.WriteLine("Equivalent to calling Ack");
            await queueClient.DeleteMessageAsync(messageToDelete.MessageId, messageToDelete.PopReceipt);

            #endregion


        }
    }

    public static class QueueExtension
    {
        public static async Task SendJsonSerializedMessageAsync<T>(this QueueClient queueClient, T obj)
        {
            string message = JsonSerializer.Serialize<T>(obj);
            await queueClient.SendMessageAsync(message);

        }
    }
}
