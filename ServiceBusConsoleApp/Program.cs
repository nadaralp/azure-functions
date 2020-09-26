using System;
using System.Threading.Tasks;

namespace ServiceBusConsoleApp
{
    class Program
    {
        static QueueService _queueService = new QueueService();
        static async Task Main(string[] args)
        {
            await _queueService.SendMessagesToQueue();
        }
    }
}
