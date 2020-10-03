using Cosmos.DataInteractionFacade.Builder;
using Cosmos.DataInteractionFacade.Data;
using CosmosDb.CrudDemo.Models;
using CosmosDb.CrudDemo.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CosmosDb.CrudDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // todo: implement key-vault extraction instead of reading from appsettings.json
            string accountEndpointUri = Configuration["CosmosDb:AccountEndpointUri"];
            string apiKey = Configuration["CosmosDb:ApiKey"];
            string databaseName = Configuration["CosmosDb:DatabaseName"];
            string collectionName = Configuration["CosmosDb:CollectionName"];

            // todo: ----> implement the following way of getting the instance
            ICosmosRepositoryBuilder cosmosRepositoryBuilder = new CosmosRepositoryBuilder(accountEndpointUri, apiKey);
            services.AddSingleton<ICosmosRepository<Todo>>(cosmosRepositoryBuilder.GetCosmosGenericRepository<Todo>(databaseName, collectionName).GetAwaiter().GetResult());
            services.AddSingleton<ITodoRepository>(cosmosRepositoryBuilder.GetCosmosRepository<TodoRepository, Todo>(databaseName, collectionName).GetAwaiter().GetResult());


            services.AddControllers();
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
