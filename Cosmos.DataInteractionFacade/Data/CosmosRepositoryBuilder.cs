using Cosmos.DataInteractionFacade.Entities;
using Microsoft.Azure.Cosmos;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cosmos.DataInteractionFacade.Data
{
    public class CosmosRepositoryBuilder
    {
        readonly string _databaseName;
        readonly string _containerName;
        readonly string _accountEndpoint;
        readonly string _key;
        public readonly CosmosClient _client;

        public CosmosRepositoryBuilder(string accountEndpoint, string key, string databaseName, string containerName)
        {
            _databaseName = databaseName;
            _containerName = containerName;
            _accountEndpoint = accountEndpoint;
            _key = key;
            _client = new CosmosClient(_accountEndpoint, _key);
        }

        public async Task<GenericCosmosRepository<T>> GetCosmosAbstractRepository<T>() where T : BaseCosmosEntity
        {
            GenericCosmosRepository<T> cosmosRepository = new GenericCosmosRepository<T>(_client, _databaseName, _containerName);
            DatabaseResponse database = await _client.CreateDatabaseIfNotExistsAsync(_databaseName);
            await database.Database.CreateContainerIfNotExistsAsync(_containerName, "/id");

            return cosmosRepository;
        }

        //public async Task<TRepository> GetCosmosRepository<TRepository>() where TRepository : AbstractCosmosRepository
        //{
           
        //}
    }


}
