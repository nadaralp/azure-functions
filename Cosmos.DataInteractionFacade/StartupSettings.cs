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
            CosmosRepositoryBuilder cosmosRepositoryClient = new CosmosRepositoryBuilder(accountEndpointUri, key, databaseName, containerName);
            services.AddSingleton<ICosmosRepository<T>>(cosmosRepositoryClient.GetCosmosAbstractRepository<T>().GetAwaiter().GetResult());
        }

    }
}
