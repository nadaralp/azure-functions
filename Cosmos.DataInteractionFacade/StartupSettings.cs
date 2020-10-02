using Cosmos.DataInteractionFacade.Data;
using Cosmos.DataInteractionFacade.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.DataInteractionFacade
{
    public static class StartupSettings
    {
        public static void AddCosmosDbInstanceSingleton<T>(
            this IServiceCollection services,
            string databaseName, 
            string containerName,
            string account,
            string key
            ) where T : BaseCosmosEntity
        {
            CosmosRepositoryClient cosmosRepositoryClient = new CosmosRepositoryClient(databaseName, containerName, account, key);
            services.AddSingleton<ICosmosRepository<T>>(cosmosRepositoryClient.GetCosmosRepositoryClient<T>().GetAwaiter().GetResult());
        }

    }
}
