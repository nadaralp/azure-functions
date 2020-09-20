using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubDemo.Data
{
    public static class StartupSetup
    {
        public static void AddDataLayerToFunctionRuntime(this IFunctionsHostBuilder builder)
        {
            string SqlConnection = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING");

            builder.Services.AddDbContext<PeopleDbContext>(
                options => options.UseSqlServer(SqlConnection));
        }
    }
}
