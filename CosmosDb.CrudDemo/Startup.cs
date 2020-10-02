using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cosmos.DataInteractionFacade;
using Cosmos.DataInteractionFacade.Data;
using CosmosDb.CrudDemo.Models;
using CosmosDb.CrudDemo.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
            // CosmosRepositoryBuilder cosmosRepositoryBuilder = new CosmosRepositoryBuilder(accountEndpointUri, apiKey);
            // services.AddSingleton<ICosmosRepository<Todo>>(cosmosRepositoryBuilder.GetCosmosAbstractRepository<Todo>(databaseName, collectionName));
            // services.AddSingleton<ITodoRepository>(cosmosRepositoryBuilder.GetRepository<TodoRepository, Todo>(databaseName, collectionName));


            // todo: ----> This is not needed
            // services.AddCosmosDbInstanceSingleton<Todo>(
            //    accountEndpointUri,
            //    apiKey,
            //    databaseName,
            //    collectionName
            //    );

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
