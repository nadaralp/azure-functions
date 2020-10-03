using Cosmos.DataInteractionFacade.Data;
using CosmosDb.CrudDemo.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDb.CrudDemo.Repository
{
    public class TodoRepository : GenericCosmosRepository<Todo>, ITodoRepository
    {
        public TodoRepository(
            CosmosClient cosmosClient,
            string databaseName,
            string containerName) : base(cosmosClient, databaseName, containerName)
        {

        }

        public async Task<IEnumerable<Todo>> GetAllDoneTasks(bool isDone)
        {
            //return await FullTableScanQueryAsync(@"select * from c where c.is_done = true");

            //_container.GetItemLinqQueryable()

            List<Todo> collection = new List<Todo>();

            using(FeedIterator<Todo> iterator = 
                _container.GetItemLinqQueryable<Todo>()
                .Where(t => t.Description == "test_description")
                .ToFeedIterator())
            {
                while(iterator.HasMoreResults)
                {
                    foreach (var item in await iterator.ReadNextAsync())
                    {
                        collection.Add(item);
                    }
                }
            }

            return collection;
        }
    }
}
