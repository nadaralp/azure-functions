using Cosmos.DataInteractionFacade.Data;
using Cosmos.DataInteractionFacade.Entities;
using Microsoft.Azure.Cosmos;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cosmos.DataInteractionFacade.Builder
{
    public class CosmosRepositoryBuilder : ICosmosRepositoryBuilder
    {
        readonly string _accountEndpoint;
        readonly string _key;
        public readonly CosmosClient _client;

        public CosmosRepositoryBuilder(string accountEndpoint, string key)
        {
            _accountEndpoint = accountEndpoint;
            _key = key;
            _client = new CosmosClient(_accountEndpoint, _key);
        }

        public async Task<GenericCosmosRepository<T>> GetCosmosGenericRepository<T>(string databaseName, string containerName) where T : BaseCosmosEntity
        {
            GenericCosmosRepository<T> cosmosRepository = new GenericCosmosRepository<T>(_client, databaseName, containerName);
            DatabaseResponse database = await _client.CreateDatabaseIfNotExistsAsync(databaseName);
            await database.Database.CreateContainerIfNotExistsAsync(databaseName, "/id");

            return cosmosRepository;
        }

        public async Task<TRepository> GetCosmosRepository<TRepository, TEntity>(string databaseName, string containerName)
            where TEntity : BaseCosmosEntity
            where TRepository : GenericCosmosRepository<TEntity>
        {
            DatabaseResponse database = await _client.CreateDatabaseIfNotExistsAsync(databaseName);
            await database.Database.CreateContainerIfNotExistsAsync(databaseName, "/id");

            TRepository repository = (TRepository)Activator.CreateInstance(typeof(TRepository), _client, databaseName, containerName);

            return repository;
        }
    }


}
