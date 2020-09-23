using FormReceiver.Publisher;
using IOService;
using IOService.AzureBlob;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace FormReceiver.Publisher
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.AddIoServiceDependencies();

            builder.Services.AddOptions<AzureStorageBlobOptions>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("AzureStorageBlobOptions").Bind(settings);
                });
        }
    }
}