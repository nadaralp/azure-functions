using FormReceiver.Publisher;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
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

            // builder.Services.AddScoped<ITestService, TestService>();
        }
    }
}