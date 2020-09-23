using IOService.AzureBlob;
using IOService.IO;
using IOService.Models;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOService
{
    public static class StartupSetup
    {
        public static void AddIoServiceDependencies(this IFunctionsHostBuilder builder)
        {
            // Register encoding for 1252 exceel
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);


            builder.Services.AddScoped<IFileIOService<SampleData>, AzureExcelReader<SampleData>>();

            builder.Services.AddScoped<AzureStorageBlobOptionsTokenGenerator>();
        }
    }
}
