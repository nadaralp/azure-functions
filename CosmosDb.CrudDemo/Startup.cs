using AutoMapper;
using Cosmos.DataInteractionFacade.Builder;
using Cosmos.DataInteractionFacade.Data;
using CosmosDb.CrudDemo.Infrastructure.KeyVault;
using CosmosDb.CrudDemo.Infrastructure.Options;
using CosmosDb.CrudDemo.Infrastructure.Security;
using CosmosDb.CrudDemo.Infrastructure.Security.Requirements;
using CosmosDb.CrudDemo.Models;
using CosmosDb.CrudDemo.Repository;
using CosmosDb.CrudDemo.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CosmosDb.CrudDemo
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // todo: implement key-vault extraction instead of reading from appsettings.json
            //var keyVaultManagerLogger = _loggerFactory.CreateLogger<KeyVaultManager>();
            //var keyVaultManager = new KeyVaultManager(Configuration, keyVaultManagerLogger);

            string accountEndpointUri = Configuration["CosmosDb:AccountEndpointUri"];
            // string accountEndpointUri = keyVaultManager.GetValue("CosmosAccountEndpointUri", "CosmosDb:AccountEndpointUri");
            string apiKey = Configuration["CosmosDb:ApiKey"];
            string databaseName = Configuration["CosmosDb:DatabaseName"];
            string collectionName = Configuration["CosmosDb:CollectionName"];

            // Declaring options
            //services.Configure<PermittedUploadTokenOptions>(Configuration.GetSection(PermittedUploadTokenOptions.sectionName));
            //var settings = Configuration.GetSection(PermittedUploadTokenOptions.sectionName).Get<PermittedUploadTokenOptions>();
            //services.AddAssemblyOptionsObjects(Configuration);


            ICosmosRepositoryBuilder cosmosRepositoryBuilder = new CosmosRepositoryBuilder(accountEndpointUri, apiKey);
            //services.AddSingleton<ICosmosRepository<Todo>>(cosmosRepositoryBuilder.GetCosmosGenericRepository<Todo>(databaseName, collectionName).GetAwaiter().GetResult());
            services.AddSingleton<ITodoService>(cosmosRepositoryBuilder.GetCosmosRepository<TodoService, Todo>(databaseName, collectionName).GetAwaiter().GetResult());
            services.AddSingleton<IStockService>(cosmosRepositoryBuilder.GetCosmosRepository<StockService, Stock>(databaseName, "stocks").GetAwaiter().GetResult());
            services.AddSingleton<IStockHolderService>(cosmosRepositoryBuilder.GetCosmosRepository<StockHolderService, StockHolder>(databaseName, "stock-holders").GetAwaiter().GetResult());


            // Automapper
            services.AddAutoMapper(typeof(Startup));

            // Add this to enable insights telemetry
            services.AddApplicationInsightsTelemetry("288ba041-7423-4f9e-a62d-4ba574e03783");


            //services.AddAuthentication(); // Adding authentication scheme
            services.AddAuthentication(o =>
            {
                o.DefaultScheme = "TokenAuthenticationScheme";
            });
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //        .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
            //            options =>
            //            {
            //                options.LoginPath = new PathString("/auth/login");
            //                options.AccessDeniedPath = new PathString("/auth/denied");
            //            });

            // Adding Security (Policy based authorization) Authorization
            //https://www.red-gate.com/simple-talk/dotnet/c-programming/policy-based-authorization-in-asp-net-core-a-deep-dive/#:~:text=Role%2Dbased%20Authorization%20in%20ASP.NET%20Core&text=You%20can%20specify%20the%20roles,controller%20or%20an%20action%20method.
            services.AddAuthorization(options =>
            {
                options.AddPolicy("StorageUpload",
                    policy => policy.Requirements.Add(new FileUploadTokenRequirement()));
            });

            // Automatically camel case the json
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                // for pascal case use NULL policy
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
