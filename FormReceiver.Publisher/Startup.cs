using FormReceiver.Publisher;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using PubSubDemo.Core.Entities;
using PubSubDemo.Data;
using PubSubDemo.Services;

[assembly: FunctionsStartup(typeof(Startup))]

namespace FormReceiver.Publisher
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.AddDataLayerToFunctionRuntime();
            builder.AddServicesToFunctionRuntime();

            // You can initialize singletons like that.
            //builder.Services.AddSingleton((x) => 
            //{
            //    var p = new MongoDbClient();
            //    return p;
            //});

            // builder.Services.AddScoped<ITestService, TestService>();
        }
    }
}