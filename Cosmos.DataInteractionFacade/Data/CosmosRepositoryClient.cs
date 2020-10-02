using Cosmos.DataInteractionFacade.Entities;
using Microsoft.Azure.Cosmos;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cosmos.DataInteractionFacade.Data
{
    public class CosmosRepositoryClient
    {
        readonly string _databaseName;
        readonly string _containerName;
        readonly string _accountEndpoint;
        readonly string _key;

        public CosmosRepositoryClient(string accountEndpoint, string key, string databaseName, string containerName)
        {
            _databaseName = databaseName;
            _containerName = containerName;
            _accountEndpoint = accountEndpoint;
            _key = key;
        }

        public async Task<AbstractCosmosRepository<T>> GetCosmosRepositoryClient<T>() where T : BaseCosmosEntity
        {

            CosmosClient client = new CosmosClient(_accountEndpoint, _key);
            AbstractCosmosRepository<T> cosmosRepository = new AbstractCosmosRepository<T>(client, _databaseName, _containerName);
            DatabaseResponse database = await client.CreateDatabaseIfNotExistsAsync(_databaseName);
            await database.Database.CreateContainerIfNotExistsAsync(_containerName, "/id");

            return cosmosRepository;
        }
    }


}
