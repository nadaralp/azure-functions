using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using PubSubDemo.Core.Services;
using PubSubDemo.Infrastructure;
using PubSubDemo.Infrastructure.Utils;
using PubSubDemo.Services.People;

namespace PubSubDemo.Services
{
    public static class StartupSetup
    {
        public static void AddServicesToFunctionRuntime(this IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<IPersonService, PersonService>();
            builder.Services.AddScoped<NameGenerator>();
        }
    }
}
