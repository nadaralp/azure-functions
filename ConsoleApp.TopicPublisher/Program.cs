using Microsoft.Azure.ServiceBus;
using ServiceBus.model;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp.TopicPublisher
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Topic Publisher - Enter Age !");
            int age = Convert.ToInt32(Console.ReadLine());

            #region Send Topic Message

            try
            {
                // You publish messages to a topic. Then the subscribers are the one triggering stuff.
                string connectoinString = "Endpoint=sb://servicebus-demo-1231.servicebus.windows.net/;SharedAccessKeyName=SenderPolicy;SharedAccessKey=O55ukmjrJoaLylEDS83JWfQ8aP6qON3jXdONgrd7XRE=";
                string topicName = "my-topic";

                ITopicClient topicClient = new TopicClient(connectoinString, topicName);

                var person = new Person
                {
                    Name = "John Doe",
                    Age = age
                };


                var msgString = JsonSerializer.Serialize(person);
                Message msg = new Message(Encoding.UTF8.GetBytes(msgString));
                msg.UserProperties["age"] = person.Age;

                Console.WriteLine("Sending message to topic.....");
                await topicClient.SendAsync(msg);
                Console.WriteLine("Message to topic was sent succesfully.");

                await topicClient.CloseAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            
            #endregion
        }
    }
}
