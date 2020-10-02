using Cosmos.DataInteractionFacade.Entities;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cosmos.DataInteractionFacade.Data
{
    // This Repository using cosmos db
    public class GenericCosmosRepository<T> : ICosmosRepository<T> where T : BaseCosmosEntity
    {

        protected Container _container;

        public GenericCosmosRepository(
            CosmosClient cosmosClient,
            string databaseName,
            string containerName)
        {
            _container = cosmosClient.GetContainer(databaseName, containerName);
        }

        #region Queries

        public async Task<T> GetByIdAsync(Guid id)
        {
            T entity = await _container.ReadItemAsync<T>(id.ToString(), new PartitionKey(id.ToString()));
            return entity;
        }

        public Task<T> GetSingleBy(Expression<Func<T, bool>> predicateExpression)
        {
            var collectionQueryable = _container.GetItemLinqQueryable<T>();
            return Task.FromResult(collectionQueryable.FirstOrDefault(predicateExpression));
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            List<T> results = new List<T>();

            using (FeedIterator<T> query = _container.GetItemQueryIterator<T>("select * from c"))
            {
                while (query.HasMoreResults)
                {
                    FeedResponse<T> response = await query.ReadNextAsync();
                    results.AddRange(response.ToList());
                }
            }

            return results;
        }

        public Task<IEnumerable<T>> GetCollectionByAsync(Expression<Func<T, bool>> predicateExpression)
        {
            var collectionQueryable = _container.GetItemLinqQueryable<T>();
            return Task.FromResult(collectionQueryable.Where(predicateExpression).AsEnumerable());
        }

        #endregion

        #region Commands

        public async Task AddSingleAsync(T entity)
        {
            try
            {
                if (entity.id == Guid.Empty)
                    entity.id = Guid.NewGuid();

                PartitionKey partitionKey = new PartitionKey(entity.id.ToString());
                await _container.CreateItemAsync(entity, partitionKey: partitionKey);
            }
            catch(Exception e) 
            {
                throw;
            }
            
        }

        public async Task AddBatchAsync(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
                await AddSingleAsync(entity);
        }

        public async Task UpdateSingleAsync(T entity)
        {
            PartitionKey partitionKey = new PartitionKey(entity.id.ToString());
            await _container.UpsertItemAsync(entity, partitionKey);
        }

        public async Task UpdateBatchAsync(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                await UpdateSingleAsync(entity);
            }
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            return await DeleteAsync(entity.id);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                PartitionKey partitionKey = new PartitionKey(id.ToString());
                await _container.DeleteItemAsync<T>(id.ToString(), partitionKey);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteBatchAsync(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
                await DeleteAsync(entity);

            return true;
        }

        public async Task<bool> DeleteBatchAsync(IEnumerable<Guid> entitiesId)
        {
            foreach (Guid id in entitiesId)
                await DeleteAsync(id);

            return true;
        }

        #endregion
    }
}
