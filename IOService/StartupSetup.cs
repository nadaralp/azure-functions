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
            builder.Services.AddScoped<IFileIOService<SampleData>, ExcelReader<SampleData>>();
        }
    }
}
