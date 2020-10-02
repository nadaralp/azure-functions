using Cosmos.DataInteractionFacade.Data;
using Cosmos.DataInteractionFacade.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.DataInteractionFacade
{
    public static class StartupSettings
    {
        public static void AddCosmosDbInstanceSingleton<T>(
            this IServiceCollection services,
            string accountEndpointUri,
            string key,
            string databaseName, 
            string containerName
            ) where T : BaseCosmosEntity
        {
            CosmosRepositoryClient cosmosRepositoryClient = new CosmosRepositoryClient(accountEndpointUri, key, databaseName, containerName);
            services.AddSingleton<ICosmosRepository<T>>(cosmosRepositoryClient.GetCosmosRepositoryClient<T>().GetAwaiter().GetResult());
        }

    }
}
